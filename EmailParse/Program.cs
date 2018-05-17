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
            string file_path = @"C:\Users\nwolf\Documents\EmailAddressFile_20180517.csv";

            // parse the csv file given in the path, determine bad email addresses, and output the results in two csv files
            Parse.ParseInput(file_path);

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
