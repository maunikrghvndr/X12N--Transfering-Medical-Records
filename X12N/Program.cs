using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X12N.Framework;
using X12N.ProtocolBL;

namespace X12N
{
    class Program
    {
        static void Main(string[] args)
        {
            String message = string.Empty;
            string fileName = string.Empty, procName = string.Empty, appName = string.Empty;

            fileName = ConfigurationManager.AppSettings["Filepath"].ToString();
            appName = ConfigurationManager.AppSettings["ServerName"].ToString();

            Base837BL base83obj = new Base837BL(fileName,appName);
            Base baseObj = base83obj.procecssMessage();
            Console.WriteLine(message);
            Console.ReadKey();
        }


        static void CreateFile(string fileName, string messageToFile)
        {
            string directoryPath = "C:\\X12N";
            string filePath = String.Concat(directoryPath, "\\", fileName);
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            if (!File.Exists(filePath))
            {
                File.Create(filePath).Dispose();
                using (TextWriter tw = new StreamWriter(filePath))
                {
                    tw.WriteLine(messageToFile);
                    tw.Close();
                }

            }


        }
    }
}
