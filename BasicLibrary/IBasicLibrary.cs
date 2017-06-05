using System;
using Microsoft.EntityFrameworkCore;


namespace BasicLibrary
{
    public interface IBasicLibrary
    {
        DbContext Context { get; set; }

        string Select(int id);
        string Select(DateTime BeginDate, DateTime EndDate);
        void Insert();
        string Update(int id);
        string Delete(int id);
    }
}
