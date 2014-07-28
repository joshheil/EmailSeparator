using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EmailSeparator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] emails = File.ReadAllLines(path: @"C:\Users\Josh\Documents\emails.txt");
            List<string> lemails = emails.ToList();
            List<string> results = new List<string>();
            byte[] resultAsBytes;
            foreach (var email in lemails)
            {
                MailAddress address = new MailAddress(email);
                results.Add(address.Host + Environment.NewLine);
            }
            resultAsBytes = results.SelectMany(s => Encoding.ASCII.GetBytes(s)).ToArray();

            File.WriteAllBytes(@"C:\Users\Josh\Documents\emailsresults.txt", resultAsBytes);
            Console.ReadLine();
        }
    }
}
