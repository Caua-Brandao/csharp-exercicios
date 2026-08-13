using System;
using System.Collections.Generic;
using System.IO;


namespace Voting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string sourcePath = @"C:\Users\cauab\OneDrive\Desktop\Voting.txt";
                Dictionary<string, int> users = new Dictionary<string, int>();
                using (StreamReader sr = new StreamReader(sourcePath))
                {
                    while (!(sr.EndOfStream))
                    {
                        string[] user = sr.ReadLine().Split(',');
                        string name = user[0].Trim();
                        int votes = int.Parse(user[1].Trim());

                        users.TryGetValue(name, out int atual);
                        users[name] = atual + votes;
                    }
                }
                foreach (var user in users)
                {
                    Console.WriteLine(user.Key + " - " + user.Value);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred. " + e.Message);
            }
        }
    }
}
