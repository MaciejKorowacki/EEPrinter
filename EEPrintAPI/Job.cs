using System;

namespace EPrintAPI
{
    /// <summary>
    /// Single Job container class
    /// </summary>
    public class Job
    {
        public long JobID { get; set; }
        public string Name { get; set; } = "";
        public string OriginalFileName { get; set; } = "";
        public string Comment { get; set; } = "";
        public bool IsHold { get; set; }
        public int LayoutWidth { get; set; }
        public int LayoutHeight { get; set; }
        public int Copies { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool StepRepeatEnabled { get; set; }
    }
}