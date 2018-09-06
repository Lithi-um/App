using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication3
{
    class Program
    {
      static int maxlen = 80;
        static void Main(string[] args)
        {

            String linefrmfile;
            try
            {
                
                StreamReader sr = new StreamReader("D:\\Sample.txt");

                //Read the first line of text
                linefrmfile = sr.ReadLine();

                //Continue to read until you reach end of file
                while (linefrmfile != null)
                {
                    if (linefrmfile.Length>maxlen)
                    {
                        Console.WriteLine(linefrmfile.Remove(80));
                        
                    }
                   else
                    {
                        //write the lie to console window
                        align(ref linefrmfile);
                        Console.WriteLine(linefrmfile);
                        //Read the next line
                       

                    }
                    linefrmfile = sr.ReadLine();

                }

                //close the file
                sr.Close();
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }

        }
        private static void align(ref string linefrmfile)
        {
            int numspaces, remainderspaces, numspace=0;
            char[] charSeparators = new char[] { ' ' };
            string[] masswords=linefrmfile.Split(charSeparators,StringSplitOptions.RemoveEmptyEntries);
             for (int len = 0; len < linefrmfile.Length; len++)
               {
                   if (linefrmfile[len] == ' ')
                   {
                       numspace++;
                   }
              }
               string finalLine = "";
               numspaces = (maxlen - (linefrmfile.Length - numspace))/numspace;
            remainderspaces = maxlen-(numspace * numspaces + (linefrmfile.Length - numspace));
               for (int words = 0; words < masswords.Length; words++)
               {
                   finalLine = finalLine + masswords[words];
                if (words < remainderspaces)
                {
                    finalLine = finalLine + " ";
                }
                for (int spaces=0;spaces<numspaces;spaces++)
                   {
                       finalLine = finalLine + " ";
                     
                   }
               }
            finalLine = finalLine.Remove(finalLine.Length - numspaces);
               Console.WriteLine(finalLine);

        }
    }
}
