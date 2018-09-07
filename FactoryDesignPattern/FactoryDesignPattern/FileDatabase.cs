using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FactoryDesignPattern
{
    class FileDatabase : IRepository
    {
        Logger logs = Logger.getInstance();
        public void AddProduct(string data, string operation)
        {
            FileStream fs = new FileStream("C:\\saveFile.txt", FileMode.Append, FileAccess.Write);

            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine(operation + ": " + data);

            logs.loggingDetails("Saving into file");

            sw.Flush();

            sw.Close();

            fs.Close();
        }
    }
}
