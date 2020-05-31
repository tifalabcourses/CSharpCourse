using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sessions.Model
{
  public static  class MySessions
    {
        public static string username { get; set; }
        public static string role { get; set; }

        public static string[] priv { get; set; }
    }
}
