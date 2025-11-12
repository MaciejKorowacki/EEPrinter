using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EEPrintAPI;

namespace EEPrintViewer
{
    public partial class Form1 : Form
    {
        private List<Job> jobs;

        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized; // fullscreen

            LoadJobs();
        }

        private void LoadJobs()
        {
            try
            {
                string dbPath = @"C:\Users\Maciej\Desktop\dummy.db";
                IEEPrintAPI api = new EEPrintAPI(dbPath);
                jobs = api.GetJobs(DateTime.Now.AddDays(-7), DateTime.Now);

                if (jobs == null || jobs.Count == 0)
                    LoadDummyJobs(); // fallback jeœli API nic nie zwróci
            }
            catch
            {
                LoadDummyJobs(); // fallback jeœli API siê nie po³¹czy
            }

            gridJobs.DataSource = jobs;
        }

        private void LoadDummyJobs()
        {
            jobs = new List<Job>
            {
                new Job { Name="Job 1", OriginalFileName="file1.pdf", IsHold=true, Comment="Test comment 1", LayoutWidth=100, LayoutHeight=200, Copies=2, StepRepeatEnabled=true, CreatedAt=DateTime.Now },
                new Job { Name="Job 2", OriginalFileName="file2.pdf", IsHold=false, Comment="Test comment 2", LayoutWidth=150, LayoutHeight=250, Copies=1, StepRepeatEnabled=false, CreatedAt=DateTime.Now.AddMinutes(-30) },
                new Job { Name="Job 3", OriginalFileName="file3.pdf", IsHold=true, Comment="Test comment 3", LayoutWidth=200, LayoutHeight=300, Copies=5, StepRepeatEnabled=true, CreatedAt=DateTime.Now.AddHours(-1) }
            };
        }

        // MenuStrip event handlers
        private void OpenFile_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Open File clicked – metoda do implementacji.");
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChangeStatus_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Change Status clicked – metoda do implementacji.");
        }

        private void About_Click(object sender, EventArgs e)
        {
            MessageBox.Show("EEPrintViewer sample GUI\nDummy jobs example", "About");
        }
    }

    public class Job
    {
        public string Name { get; set; } = "";
        public string OriginalFileName { get; set; } = "";
        public bool IsHold { get; set; }
        public string Comment { get; set; } = "";
        public string Comment { get; set; } = "";
        public int LayoutWidth { get; set; }
        public int LayoutHeight { get; set; }
        public int Copies { get; set; }
        public bool StepRepeatEnabled { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
