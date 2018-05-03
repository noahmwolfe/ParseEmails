using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace EmailParse
{
    public class Parse
    {
        static public List<string> ParseInput()
        {

            List<string> output = new List<string>();

                using (var reader = new StreamReader(@"C:\Users\nwolf\Documents\test.csv"))
                {

                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var emails = line.Split(',');
                        for(int i = 0; i < emails.Length; ++i)
                        {
                            output.Add(emails[i]);
                        }
                    }
                }
            

            return output;
        }

        static public void ParseEmails(List<string> all_emails)
        {
            var good_csv = new StringBuilder();
            var bad_csv = new StringBuilder();

            Regex r = new Regex(@"^([a-z0-9][-a-z0-9_\+\.]*[a-z0-9])@([a-z0-9][-a-z0-9\.]*[a-z0-9]\.(arpa|root|aero|biz|cat|com|coop|edu|gov|info|int|jobs|mil|mobi|museum|name|net|org|pro|tel|travel)|([0-9]{1,3}\.{3}[0-9]{1,3}))");

            for (int i = 0; i < all_emails.Count; ++i)
            {
                Console.WriteLine(all_emails[i]);

                Match m = r.Match(all_emails[i]);
                if (m.Success)
                {
                    Console.WriteLine("Is an email address");
                    good_csv.AppendLine(string.Join(",", all_emails[i]));
                } else
                {
                    Console.WriteLine("not an email address");
                    bad_csv.AppendLine(string.Join(",", all_emails[i]));
                }
            }
            File.WriteAllText(@"C:\Users\nwolf\Documents\good_emails.csv", good_csv.ToString());
            File.WriteAllText(@"C:\Users\nwolf\Documents\bad_emails.csv", bad_csv.ToString());
        }
    }
}
