using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace X12N.HelperCLass
{
    class FileManager
    {

        public static string WriteFile(string fileName, string messageToFile)
        {


            string directoryPath = ConfigurationManager.AppSettings["Filepath"].ToString(); ;
            string ifileName = String.Empty;
            if (String.IsNullOrEmpty(fileName))
                ifileName = String.Format("4042_P_{0}{1}.837", DateTime.Now.ToString("yyyyMMdd"), DateTime.Now.ToString("HHmmss"));
            else
                ifileName = fileName;

            string filePath = String.Concat(directoryPath, "\\", ifileName);
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            if (!File.Exists(filePath))
                File.Create(filePath).Dispose();

            using (StreamWriter tw = File.AppendText(filePath))
            {
                tw.Write(messageToFile);
                tw.Close();
            }
            return ifileName;

        }
    }
}
