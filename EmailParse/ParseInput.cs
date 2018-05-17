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
        static public void ParseInput(string file_path)
        {
            // csv for good and bad email addresses
            var good_csv = new StringBuilder();
            var bad_csv = new StringBuilder();
            var duplicate_csv = new StringBuilder();

            // hash set to determine if the ID has been seen before
            HashSet<string> id_set = new HashSet<string>();

            // regex expression to filter out the majority of bad email addresses
            Regex r = new Regex(@"^([a-z0-9][-a-z0-9_\+\.\-]*[a-z0-9_$!])@(([a-z0-9][-a-z0-9\.]*[a-z0-9]|q|g)\.(arpa|root|aero|biz|cat|cc|co|com|coop|edu|fm|gov|info|int|jobs|mil|mobi|museum|name|net|org|pro|tel|travel|tv|us|ws)|([0-9]{1,3}\.{3}[0-9]{1,3}))");

            Console.WriteLine("Working...");

            // read in each row in the csv and parse
            using (var reader = new StreamReader(file_path))
            {

                while (!reader.EndOfStream)
                {

                    var line = reader.ReadLine();
                    var emails = line.Split(',');
                    // check if the email address has white space at the beginning (many did) and remove if it does (screws up regex otherwise)
                    if (Char.IsWhiteSpace(emails[7][0]))
                    {
                        emails[7] = emails[7].Substring(1);
                    }

                    // attempt to add the ID to the hash set and determine if it has been seen before
                    if (id_set.Add(emails[0]))
                    {
                        // determine if the regex is a match (email address needs to be in lowercase only) and append the original line to the respective csv
                        Match m = r.Match(emails[7].ToLower());
                        if (m.Success)
                        {
                            good_csv.AppendLine(line);
                        }
                        else
                        {
                            bad_csv.AppendLine(line);
                        }
                    }
                    else
                    {
                        duplicate_csv.AppendLine(line);
                    }
                }
            }

            Console.WriteLine("Finished!");

            // write the results to the respective csv files
            File.WriteAllText(@"C:\Users\nwolf\Documents\good_emails_2.csv", good_csv.ToString());
            File.WriteAllText(@"C:\Users\nwolf\Documents\bad_emails_2.csv", bad_csv.ToString());
            File.WriteAllText(@"C:\Users\nwolf\Documents\duplicate_emails_2.csv", duplicate_csv.ToString());
        }
    }
}