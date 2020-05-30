using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SavePdfToDatabase.Util
{
    class FileHelper
    {
        public static void copyFile(string source , string dist)
        {
            string sourceFile = source;
            string destinationFile = dist;
            try
            {
              
                File.Copy(sourceFile, destinationFile, false);
            }
            catch (IOException iox)
            {
                Console.WriteLine(iox.Message);
            }
        }

        public static void deleteFile(string filename)
        {
            if (File.Exists(filename))
            {
                // If file found, delete it    
                File.Delete(filename);
                Console.WriteLine("File deleted.");
            }
        }
    }
}
