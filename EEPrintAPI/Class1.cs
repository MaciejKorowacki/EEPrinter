using System.Collections.Generic;

namespace EEPrintAPI
{
    // Prosta klasa Job
    public class Job
    {
        public string Name { get; set; }
        public string OriginalFileName { get; set; }
        public bool IsHold { get; set; }
        public string Comment { get; set; }
        public int LayoutWidth { get; set; }
        public int LayoutHeight { get; set; }
        public int Copies { get; set; }
        public bool StepRepeatEnabled { get; set; }
    }

    // Interfejs minimalny
    public interface IEEPrintAPI
    {
        List<Job> GetJobs();
        List<Job> GetJobByName(string name);
        void SetComment(long id, string comment);
        void SetCopies(long id, int copies);
        void SetState(long id, bool state);
    }

    // Minimalna implementacja
    public class EEPrintAPI : IEEPrintAPI
    {
        public EEPrintAPI(string filename)
        {
            // nic nie robimy
        }

        public List<Job> GetJobs() => new List<Job>(); // zwraca pustą listę
        public List<Job> GetJobByName(string name) => new List<Job>();
        public void SetComment(long id, string comment) { }
        public void SetCopies(long id, int copies) { }
        public void SetState(long id, bool state) { }
    }
}
