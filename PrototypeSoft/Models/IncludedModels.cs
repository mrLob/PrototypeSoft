using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Runtime;
using System.Runtime.Loader;
using BasicLibrary;

namespace PrototypeSoft.Models
{
    public class IncludedModels
    {
        private List<string> ListFiles;
        private List<BaseModel> ListIncludedModels;

        public IncludedModels(string FileName)
        {
            StreamReader file = File.OpenText(FileName);
            ListFiles = new List<string>();
            ListIncludedModels = new List<BaseModel>();
            string connectionString = "";
            if (!file.EndOfStream)
                connectionString = file.ReadLine().Trim();
            else
                new Exception("Не указана строка подлючения");
            while (!file.EndOfStream)
            {
                string a = Directory.GetCurrentDirectory();
                string str = file.ReadLine().Trim();
                if (str != "")
                {
                    ListFiles.Add(str);
                    var myAssembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(Directory.GetCurrentDirectory()+@"\"+str);
                    string NameModel = str.Substring(0, str.IndexOf(".dll"));
                    var myType = myAssembly.GetType(NameModel+"."+ NameModel);
                    ListIncludedModels.Add(new BaseModel { NameModel = NameModel, Model = (IBasicLibrary)Activator.CreateInstance(myType, connectionString) });
                }

            }

        }

        private void OpenLib(string LibName)
        {
            var myAssembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(LibName);
            var myType = myAssembly.GetType("Invoice.Class1");
            //dynamic myInstance = Activator.CreateInstance(myType);
            //string a = myInstance.GetTable(1);
            IBasicLibrary Invoice = (IBasicLibrary)Activator.CreateInstance(myType);
            string a = Invoice.Select(1);

        }

        public string Get(string tablename, int id)
        {
            //OpenLib(tablename);
            var model = ListIncludedModels.Where(a => a.NameModel == tablename).First();
            string s = model.Model.Select(1);
            return s;
        }

        public void Set(string tablename)
        {
            var model = ListIncludedModels.Where(a => a.NameModel == tablename).First();
            model.Model.Insert();
        }
    }
}
