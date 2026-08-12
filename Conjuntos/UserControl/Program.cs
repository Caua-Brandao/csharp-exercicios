using System;
using System.Collections.Generic;
using System.IO;
using UserControl.Entities;

namespace UserControl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string sourcePath = @"C:\Users\cauab\OneDrive\Desktop\userControl.txt";
                HashSet<LogRecord> users = new HashSet<LogRecord>();
                using (StreamReader sr = new StreamReader(sourcePath))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] line = sr.ReadLine().Split(' ');
                        users.Add(new LogRecord(line[0], DateTime.Parse(line[1])));
                    }
                }
                Console.WriteLine("Total users: " + users.Count);
            }
            catch (IOException e)
            {
                Console.WriteLine("An error ocurred" + e.Message);
            }
        }
    }
}
