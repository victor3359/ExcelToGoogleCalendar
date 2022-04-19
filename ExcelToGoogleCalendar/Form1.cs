using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.Security;
using System.Diagnostics;

using OfficeOpenXml;
using Microsoft.Extensions.Configuration;

namespace ExcelToGoogleCalendar
{
    public partial class ShinAnBan : Form
    {
        static string[] Scopes = { CalendarService.Scope.Calendar };
        static string ApplicationName = "Excel To Google Calendar for ShinAnBan";
        static string CalendarId = "";
        private List<Event> DB = new List<Event>();
        private List<string> DoctorList = new List<string>();
        static List<string> MonthList = new List<string>()
        {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
        };
        private List<Doctor> doctors = new List<Doctor>();

        static string logPath = $"執行紀錄-{DateTime.Now.Year}{DateTime.Now.Month}{DateTime.Now.Day}{DateTime.Now.Hour}{DateTime.Now.Minute}{DateTime.Now.Second}.log";

        UserCredential credential;
        public ShinAnBan()
        {
            InitializeComponent();

            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            using (var stream =
               new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.FromStream(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }
            SyncToGoogle.Enabled = false;
        }

        private void LoadFile_Click(object sender, EventArgs e)
        {
            if (LoadExcelDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var filePath = LoadExcelDialog.FileName;
                    using (Stream str = LoadExcelDialog.OpenFile())
                    {
                        ExcelPackage ep = new ExcelPackage(new FileInfo(filePath));
                        foreach(var month in MonthList)
                        {
                            var ws = ep.Workbook.Worksheets.SingleOrDefault(x => x.Name == month);
                            if(ws == null)
                            {
                                using (StreamWriter logWritter = File.AppendText(logPath))
                                {
                                    Log($"找不到 {month} 工作表", logWritter);
                                }
                                continue;
                            }
                            for (int row = 2; row <= ws.Dimension.End.Row; row++)
                            {
                                if (ws.Cells[row, 2].Value == null || ws.Cells[row, 3].Value == null || ws.Cells[row, 4].Value == null || ws.Cells[row, 5].Value == null)
                                {
                                    continue;
                                }
                                DateTime date = DateTime.FromOADate(long.Parse(ws.Cells[row, 3].Value.ToString()));
                                DateTime Strtime = DateTime.Parse(ws.Cells[row, 4].Value.ToString());
                                DateTime Endtime = DateTime.Parse(ws.Cells[row, 5].Value.ToString());
                                DB.Add(new Event
                                {
                                    Id = $"anban{date.Year}{month}{row}",
                                    Summary = $"{ws.Cells[row, 1].Value}*{ws.Cells[row, 2].Value}老師*({ws.Cells[row, 10].Value})*{ws.Cells[row, 6].Value}/hr",
                                    Location = "",
                                    Description = "",
                                    Start = new EventDateTime()
                                    {
                                        DateTime = new DateTime(date.Year, date.Month, date.Day, Strtime.Hour, Strtime.Minute, Strtime.Second),
                                        TimeZone = "Asia/Taipei",
                                    },
                                    End = new EventDateTime()
                                    {
                                        DateTime = new DateTime(date.Year, date.Month, date.Day, Endtime.Hour, Endtime.Minute, Endtime.Second),
                                        TimeZone = "Asia/Taipei",
                                    },
                                    Recurrence = new List<string> { },
                                    Attendees = new List<EventAttendee>
                                    {
                                        new EventAttendee() { Email = Program.Configuration.GetSection("E-mail").Value }
                                    }
                                });
                                DoctorList.Add(ws.Cells[row, 2].Value.ToString());
                            }
                        }
                        LoadMessage.ForeColor = Color.Green;
                        LoadMessage.Text = "讀取那是相當成功";
                        using (StreamWriter logWritter = File.AppendText(logPath))
                        {
                            Log($"讀取 {filePath} 檔案 OK", logWritter);
                        }
                        SyncToGoogle.Enabled = true;
                    }
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"你媽雞雞到處出錯 靠北");
                    using (StreamWriter logWritter = File.AppendText(logPath))
                    {
                        Log($"你媽雞雞到處出錯\n靠北\n{ex.Message}", logWritter);
                    }
                }
            }
            else
            {
                LoadMessage.ForeColor = Color.Red;
                LoadMessage.Text = "你是取消選擇的小調皮";
                using (StreamWriter logWritter = File.AppendText(logPath))
                {
                    Log($"大雞雞亂取消選擇？", logWritter);
                }
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadConfig();
        }
        private void LoadConfig()
        {
            doctors = Program.Configuration.GetSection("Doctors").Get<List<Doctor>>();
        }
        private void UpdateConfig()
        {
            LoadConfig();
            using (StreamWriter logWritter = File.AppendText(logPath))
            {
                Log($"治療師名單更新 OK", logWritter);
            }
        }
        private void SyncToGoogle_Click(object sender, EventArgs e)
        {
            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            LoadMessage.Text = $"同步至 Google 行事曆";
            LoadMessage.ForeColor = Color.Green;
            int index = 0;
            foreach (var singleEvent in DB)
            {
                var doctor = doctors.Find(d => d.name == DoctorList[index]);
                if(doctor == null)
                {
                    LoadMessage.ForeColor = Color.Red;
                    LoadMessage.Text = $"找不到 {DoctorList[index]} 老師的行事曆";
                    using (StreamWriter logWritter = File.AppendText(logPath))
                    {
                        Log($"Google 同步錯誤：\n找不到 {DoctorList[index]} 老師的行事曆", logWritter);
                    }
                }
                else
                {
                    CalendarId = doctor.calendarId;
                    try
                    {
                        service.Events.Insert(singleEvent, CalendarId).Execute();

                    }
                    catch (Exception)
                    {
                        try
                        {
                            service.Events.Update(singleEvent, CalendarId, singleEvent.Id).Execute();
                        }
                        catch (Exception err)
                        {
                            LoadMessage.ForeColor = Color.Red;
                            LoadMessage.Text = $"插你馬眼直接爆開";
                            using (StreamWriter logWritter = File.AppendText(logPath))
                            {
                                Log($"Google 同步錯誤：\n{err.Message}", logWritter);
                            }
                        }
                    }
                }
                index++;
            }
            MessageBox.Show("同步 OK", "訊息", MessageBoxButtons.OK);
        }

        private void ModifyDoctor_Click(object sender, EventArgs e)
        {
            Process config = new Process();
            config.StartInfo.FileName = "notepad.exe";
            config.StartInfo.Arguments = "doctorlist.json";
            config.EnableRaisingEvents = true;
            config.Exited += new EventHandler(Config_Is_Done);
            config.Start();
        }

        private void Config_Is_Done(object sender, EventArgs e)
        {
            UpdateConfig();
        }

        private static void Log(string logMessage, TextWriter w)
        {
            w.Write("\r\n紀錄時間 : ");
            w.WriteLine($"{DateTime.Now.ToLongDateString()} {DateTime.Now.ToLongTimeString()} ");
            w.WriteLine($"{logMessage}");
            w.WriteLine("-------------------------------");
        }
    }
}
