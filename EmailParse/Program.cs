using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailParse
{
    class Program
    {
        static void Main(string[] args)
        {
            // parse the csv/xls/delimited file and return an array of the individual cells
            List<string> emails = Parse.ParseInput();

            // parse the individual cells and write the output to a csv file
            Parse.ParseEmails(emails);

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
