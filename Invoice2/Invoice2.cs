using System;
using BasicLibrary;
using Microsoft.EntityFrameworkCore;

namespace Invoice2
{
    public class Invoice2 : IBasicLibrary
    {
        private DbContext context;

        public DbContext Context
        {
            get
            {
                return context;
            }
            set
            {
                context = value;
            }
        }

        public Invoice2(string con)
        {
            context = new ApplicationContext(con);
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert()
        {
            //throw new NotImplementedException();
        }

        public string Select(int id)
        {
            return "Ура !!!!! это номер 2 ах да и " + id;
        }

        public string Select(DateTime BeginDate, DateTime EndDate)
        {
            throw new NotImplementedException();
        }

        public string Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
