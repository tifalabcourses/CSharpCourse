using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace GlobalConnectionInApp1.Util
{
    class DbHelper
    {
         public static string connetionString = @"Data Source=TIFALAB\MSSQL16;Initial Catalog=School;Trusted_Connection=true;";
         static   SqlConnection cnn   = new SqlConnection(connetionString);



        

               public static SqlConnection getCon()
        {
               return cnn;
        }
    }
}
