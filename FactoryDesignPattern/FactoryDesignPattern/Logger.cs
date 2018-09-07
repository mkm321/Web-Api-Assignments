using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace FactoryDesignPattern
{
    class Logger
    {
        private static Logger _Logger = null;
        private static Object _classLock = typeof(Logger);

        private Logger()
        {

        }

        public static Logger getInstance()
        {
            //lock object to make it thread safe  
            lock (_classLock)
            {
                if (_Logger == null)
                {
                    _Logger = new Logger();

                }
            }
            return _Logger;
        }

        public void loggingDetails(string detailedLog)
        {
            FileStream fs = new FileStream("C:\\logFile.txt", FileMode.Append, FileAccess.Write);

            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine(detailedLog);

            sw.Flush();

            sw.Close();

            fs.Close();
        }
    }
}