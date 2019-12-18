using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml;

namespace Q3WebService.Models
{
    public class FileProcessing
    {

        public static int Process(string FileName)
        {
            Declaration currentDeclaration = new Declaration();
            XmlReader xmlReader = XmlReader.Create(FileName);

            while (xmlReader.Read())
            {
                if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "Declaration")
                {
                    string commandValue = xmlReader.GetAttribute("Command");
                    if (commandValue.Equals("DEFAULT"))
                        currentDeclaration.Command = commandValue;
                    else
                        return -1;
                }
                if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "Jurisdiction")
                {
                    xmlReader.Read();
                    string jurisdictionValue = xmlReader.Value;
                    currentDeclaration.Jurisdiction = jurisdictionValue;
                }
                if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "CWProcedure")
                {
                    xmlReader.Read();
                    string cwProcedureValue = xmlReader.Value;
                    currentDeclaration.CwProcedure = cwProcedureValue;
                }
                if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "DeclarationDestination")
                {
                    xmlReader.Read();
                    string destinationValue = xmlReader.Value;
                    currentDeclaration.Destination = destinationValue;
                }
                if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "DocumentRef")
                {
                    xmlReader.Read();
                    string documentRefValue = xmlReader.Value;
                    currentDeclaration.DocumentRef = documentRefValue;
                }
                if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "SiteID")
                {
                    xmlReader.Read();
                    string siteIdValue = xmlReader.Value;
                    if (siteIdValue.Equals("DUB"))
                        currentDeclaration.SiteId = siteIdValue;
                    else
                        return -2;

                }
                if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "AccountCode")
                {
                    xmlReader.Read();
                    string accountCodeValue = xmlReader.Value;
                    currentDeclaration.AccountCode = accountCodeValue;
                }
            }
            return 0;
        }
    }
}
