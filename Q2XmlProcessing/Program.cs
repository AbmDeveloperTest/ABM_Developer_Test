using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Q2XmlProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            const string Reference = "Reference";
            const string RefCode = "RefCode";
            const string RefText = "RefText";

            string refCodeValue = null;
            string refTextValue = null;
            bool addToSearchResults = false;
            Dictionary<string, string> searchResults = new Dictionary<string, string>();                       

            //Read in xml file
            XmlReader xmlReader = XmlReader.Create("Q2RefTextFile.xml");

            while (xmlReader.Read()) 
            {
                if(xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == Reference)
                {
                    string currentRefCode = xmlReader.GetAttribute(RefCode);
                    if (currentRefCode.Equals("MWB") || currentRefCode.Equals("TRV") || currentRefCode.Equals("CAR"))
                    {
                        refCodeValue = currentRefCode;
                        addToSearchResults = true;
                    }

                }

                if (addToSearchResults && xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == RefText)
                {
                    //Move current read position forward to read RefText value
                    xmlReader.Read();
                    refTextValue = xmlReader.Value;

                }

                if(xmlReader.NodeType == XmlNodeType.EndElement && xmlReader.Name == Reference)
                {
                    if(addToSearchResults && refCodeValue != null && refTextValue != null && !searchResults.ContainsKey(refCodeValue))
                        searchResults.Add(refCodeValue, refTextValue);

                    refCodeValue = null;
                    refTextValue = null;
                    addToSearchResults = false;
                }

            }

            //print results
            if (searchResults.Count <= 0)
                Console.WriteLine("No matching reference codes found");
            else
            {
                foreach(KeyValuePair<string,string> kvp in searchResults)
                {
                    Console.WriteLine(RefCode + ": " + kvp.Key);
                    Console.WriteLine(RefText + ": " + kvp.Value);
                    Console.WriteLine(Environment.NewLine);
                }
                Console.ReadLine();
            }
            


        }
    }
}
