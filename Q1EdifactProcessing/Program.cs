using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1EdifactProcessing
{
    class Program
    {
        static void Main(string[] args)
        {

            StreamReader sr = File.OpenText("EdifactText.txt");

            //read file contents to string
            string fileContents = sr.ReadToEnd();
            //split string into segments 
            string[] segments = fileContents.Split('\'');

            List<string> resultValues = new List<string>();

            //Identify LOC segments then add the elements in those segments to the resultValues list
            foreach (string segment in segments) 
            {
                if (!segment.Contains("LOC"))
                    continue;

                string[] elements = segment.Split('+');
                foreach(string element in elements)
                {
                    if (element.Contains("LOC"))
                        continue;
                    resultValues.Add(element);
                }
            }

            //Copy resultsValues list to array to meet array output requirement mentioned in specification
            string[] resultArray = resultValues.ToArray();

            //Print results to console
            Console.WriteLine("Elements located in 'LOC' segments:");
            foreach (string element in resultArray)
            {
                Console.WriteLine("[" + element + "]");
            }
            Console.ReadLine();

        }
    }
}
