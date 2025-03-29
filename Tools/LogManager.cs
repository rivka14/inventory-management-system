using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public static class LogManager
    {
        private static string log = "Log";

        public static string getPathByMonth()
        {
            return log + "/" + DateTime.Now.Month.ToString();
        }
        public static string getPathByDay()
        {
            return getPathByMonth() + "/" + DateTime.Now.Day.ToString() + ".txt";
        }
        public static void writeToLog(string projectName, string funcName, string messeage)
        {
            if (!(Directory.Exists(getPathByMonth())))
            {
                DirectoryInfo d = Directory.CreateDirectory(getPathByMonth());
            }
            if (!File.Exists(getPathByDay()))
            {
                File.Create(getPathByDay()).Close();
            }
            using (StreamWriter writer = new StreamWriter(getPathByDay(), true))
            {
                writer.WriteLine($"{DateTime.Now}\t{projectName}.{funcName}:\t{messeage}");
            }
        }
        public static void DeleteLog()
        {
            string[] dirs = Directory.GetDirectories(log);
            for (int i = 0; i < dirs.Length; i++)
            {
                int monthBefore;
                string month = dirs[i].Substring(dirs[i].Length - 2);
                if (DateTime.Now.Month == 1)
                    monthBefore = 12;
                else
                    monthBefore = DateTime.Now.Month - 1;
                if (month != DateTime.Now.Month.ToString() && month != monthBefore.ToString())
                    Directory.Delete(dirs[i], true);
            }
        }

    }
}
