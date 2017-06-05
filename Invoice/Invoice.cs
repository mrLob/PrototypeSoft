using System;
using BasicLibrary;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.IO;
using Newtonsoft.Json;

namespace Invoice
{
    public class Invoice : IBasicLibrary
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

        public Invoice(string con)
        {
            context = new ApplicationContext(con);
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert()
        {
            Table t = new Table();
            t.Name = "Ура я это сделал";
            t.Date = DateTime.Now.Date;
            ApplicationContext MyContext = context as ApplicationContext;
            MyContext.Invoice.Add(t);
            MyContext.SaveChanges();
        }

        public string Select(int id)
        {
            ApplicationContext MyContext = context as ApplicationContext;
            var element =  MyContext.Invoice.Where(a => a.Id == id).First();

            //StringWriter sw = new StringWriter();
            //JsonTextWriter writer = new JsonTextWriter(sw);

            //writer.WriteStartObject();

            //writer.WritePropertyName("Id");
            //writer.WriteValue(element.Id);

            //writer.WritePropertyName("Date");
            //writer.WriteValue(element.Date);

            //writer.WritePropertyName("Name");
            //writer.WriteValue(element.Name);

            //writer.WriteEndObject();

            //return sw.ToString();
            return element.Name;
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
