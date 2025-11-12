using System;
using System.Collections.Generic;
using System.Linq;

namespace EEPrintAPI
{
    public class EEPrintAPI : IEEPrintAPI
    {
        private readonly string _fileName;
        private List<Job> _jobs;

        public EEPrintAPI(string fileName)
        {
            _fileName = fileName;
            LoadDummyJobs();
        }

        private void LoadDummyJobs()
        {
            // Dummy data do testowania
            _jobs = new List<Job>
            {
                new Job { JobID = 1, Name="Job 1", OriginalFileName="file1.pdf", IsHold=true, Comment="Test comment 1", LayoutWidth=100, LayoutHeight=200, Copies=2, CreatedAt=DateTime.Now },
                new Job { JobID = 2, Name="Job 2", OriginalFileName="file2.pdf", IsHold=false, Comment="Test comment 2", LayoutWidth=150, LayoutHeight=250, Copies=1, CreatedAt=DateTime.Now.AddMinutes(-30) },
                new Job { JobID = 3, Name="Job 3", OriginalFileName="file3.pdf", IsHold=true, Comment="Test comment 3", LayoutWidth=200, LayoutHeight=300, Copies=5, CreatedAt=DateTime.Now.AddHours(-1) }
            };
        }

        public List<Job> GetJobs(DateTime startDate, DateTime endDate)
        {
            // Dummy filter po dacie
            return _jobs.Where(j => j.CreatedAt >= startDate && j.CreatedAt <= endDate).ToList();
        }

        public List<Job> GetJobByName(string name)
        {
            return _jobs.Where(j => j.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Job> GetJobByOriginalFileName(string fileName)
        {
            return _jobs.Where(j => j.OriginalFileName.Contains(fileName, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Job> GetJobByID(long id)
        {
            return _jobs.Where(j => j.JobID == id).ToList();
        }

        public void SetState(long id, bool state)
        {
            var job = _jobs.FirstOrDefault(j => j.JobID == id);
            if (job != null)
                job.IsHold = state;
        }

        public void SetComment(long id, string comment)
        {
            var job = _jobs.FirstOrDefault(j => j.JobID == id);
            if (job != null)
                job.Comment = comment;
        }

        public void SetCopies(long id, int copies)
        {
            var job = _jobs.FirstOrDefault(j => j.JobID == id);
            if (job != null)
                job.Copies = copies;
        }

        public void SetLayoutWidthAndHeight(long id, int width, int height)
        {
            var job = _jobs.FirstOrDefault(j => j.JobID == id);
            if (job != null)
            {
                job.LayoutWidth = width;
                job.LayoutHeight = height;
            }
        }
    }
}
