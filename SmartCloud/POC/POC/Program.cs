using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POC
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine(args[0].ToString());
                Console.WriteLine(args[1].ToString());

                Console.WriteLine("Executed!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
