using System;
using System.IO;

namespace fileTopgSQL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateReadFile();
        }
        /*
        Method      :   CreateReadFile
        Description :   Method to create/read dummy file on any OS 
        */
        public static void CreateReadFile()
        {
            try{
                string path = System.Reflection.Assembly.GetEntryAssembly().Location;
                path = path.Substring(0,path.LastIndexOf(Path.DirectorySeparatorChar));
                path = path + Path.DirectorySeparatorChar + DateTime.Now.Ticks.ToString();
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("Scribble");
                    sw.WriteLine("on");
                    sw.WriteLine("any Platform");
                }

                using (StreamReader sr = File.OpenText(path))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Something went wrong :(");
                Console.WriteLine("Here is the StackTrace:" + ex.StackTrace);
            }
        }
    }
}
