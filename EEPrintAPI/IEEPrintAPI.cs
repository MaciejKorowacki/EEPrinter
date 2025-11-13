using System;
using System.Collections.Generic;

namespace EPrintAPI
{
    public interface IEEPrintAPI
    {
        List<Job> GetJobs(DateTime startDate, DateTime endDate);
        List<Job> GetJobByName(string name);
        List<Job> GetJobByOriginalFileName(string fileName);
        List<Job> GetJobByID(long id);
        void SetState(long id, bool state);
        void SetComment(long id, string comment);
        void SetCopies(long id, int copies);
        void SetLayoutWidthAndHeight(long id, int width, int height);
    }
}
