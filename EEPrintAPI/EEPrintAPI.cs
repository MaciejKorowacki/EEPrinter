using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;

namespace EPrintAPI
{
    public class EEPrintAPI : IEEPrintAPI
    {
        private List<Job> _jobs = new List<Job>(); // non-nullable
        private readonly string _fileName;

        public EEPrintAPI(string fileName)
        {
            _fileName = fileName;

            // Try loading from database first
            bool loadedFromDb = TryLoadFromDatabase();

            if (!loadedFromDb)
            {
                // Fallback to dummy jobs
                LoadDummyJobs();
            }
        }

        private bool TryLoadFromDatabase()
        {
            try
            {
                if (!File.Exists(_fileName))
                {
                    Console.WriteLine("Database file not found: " + _fileName);
                    return false;
                }

                using var connection = new SQLiteConnection($"Data Source={_fileName};Version=3;");
                connection.Open();

                // Check if table exists
                using (var cmd = new SQLiteCommand("SELECT name FROM sqlite_master WHERE type='table' AND name='Job';", connection))
                {
                    var result = cmd.ExecuteScalar();
                    if (result == null)
                    {
                        Console.WriteLine("Table 'Job' does not exist.");
                        return false;
                    }
                }

                string query = "SELECT * FROM Job;";
                using var cmd2 = new SQLiteCommand(query, connection);
                using var reader = cmd2.ExecuteReader();

                int rowCount = 0;
                _jobs.Clear();

                while (reader.Read())
                {
                    rowCount++;
                    if (rowCount <= 10) // print first 10 rows for debugging
                    {
                        Console.WriteLine($"--- Row {rowCount} ---");
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            string colName = reader.GetName(i);
                            string value = reader[i]?.ToString() ?? "(null)";
                            Console.WriteLine($"{colName}: {value}");
                        }
                    }

                    // Map database row to Job class
                    _jobs.Add(new Job
                    {
                        JobID = Convert.ToInt64(reader["JobID"]),
                        Name = reader["JobName"]?.ToString() ?? "",
                        OriginalFileName = reader["OriginalFileName"]?.ToString() ?? "",
                        IsHold = Convert.ToInt32(reader["JobStatus"]) != 0,
                        Comment = "",
                        LayoutWidth = 0,
                        LayoutHeight = 0,
                        Copies = 1,
                        CreatedAt = DateTime.Now, // placeholder since DB has no CreatedAt
                        StepRepeatEnabled = false
                    });
                }

                if (rowCount == 0)
                {
                    Console.WriteLine("No rows found in Job table.");
                    return false;
                }

                Console.WriteLine($"Loaded {rowCount} jobs from database.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Database load failed: " + ex.Message);
                return false;
            }
        }

        private void LoadDummyJobs()
        {
            _jobs = new List<Job>
            {
                new Job { JobID = 1, Name="Job 1", OriginalFileName="file1.pdf", IsHold=true, Comment="Test comment 1", LayoutWidth=100, LayoutHeight=200, Copies=2, StepRepeatEnabled=true, CreatedAt=DateTime.Now },
                new Job { JobID = 2, Name="Job 2", OriginalFileName="file2.pdf", IsHold=false, Comment="Test comment 2", LayoutWidth=150, LayoutHeight=250, Copies=1, StepRepeatEnabled=false, CreatedAt=DateTime.Now.AddMinutes(-30) },
                new Job { JobID = 3, Name="Job 3", OriginalFileName="file3.pdf", IsHold=true, Comment="Test comment 3", LayoutWidth=200, LayoutHeight=300, Copies=5, StepRepeatEnabled=true, CreatedAt=DateTime.Now.AddHours(-1) }
            };

            Console.WriteLine("Loaded dummy jobs as fallback.");
        }

        // Public API methods
        public List<Job> GetJobs(DateTime startDate, DateTime endDate)
        {
            // Ignore CreatedAt filtering since DB has no date
            return _jobs;
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
            if (job != null) job.IsHold = state;
        }

        public void SetComment(long id, string comment)
        {
            var job = _jobs.FirstOrDefault(j => j.JobID == id);
            if (job != null) job.Comment = comment;
        }

        public void SetCopies(long id, int copies)
        {
            var job = _jobs.FirstOrDefault(j => j.JobID == id);
            if (job != null) job.Copies = copies;
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
