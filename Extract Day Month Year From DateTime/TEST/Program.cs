using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TEST
{
     class Program
    {
  
        static void Main()
        {
            var dt = DateTime.Now;

            Console.WriteLine(dt.ToString("d")); //4/11/2020

            Console.WriteLine(dt.ToString("MM"));
            Console.WriteLine(dt.ToString("dd"));
            Console.WriteLine(dt.ToString("yyyy"));

            Console.WriteLine(dt.ToString("MM/dd/yyyy"));//04/11/2020
            Console.WriteLine(dt.ToString("dddd, dd MMMM yyyy"));//Saturday, 11 April 2020
            Console.WriteLine(dt.ToString("MM/dd/yyyy h:mm tt"));//04/11/2020 1:21 AM

            //Console.WriteLine(dt.ToString("MMMM dd"));
          //  01:35:53
           // 01:35 AM
            Console.WriteLine(dt.ToString("HH:mm:ss"));
            Console.WriteLine(dt.ToString("hh:mm tt"));

            Console.WriteLine("-------------------");
            Console.WriteLine(dt.ToShortDateString());
            Console.WriteLine(dt.ToLongDateString());
            Console.WriteLine(dt.ToShortTimeString());
            Console.WriteLine(dt.ToLongTimeString());




        }
    }
}
