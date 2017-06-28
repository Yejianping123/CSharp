using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.XPath;

/*
 * Service implementation for validating xml and adding new person
 */ 
public class Service : IService
{
    private static string status = "Valid";
    private static Boolean flag = false;
    private static string msg;

    /*
     * Service to validate XML using XSD
     * A XML URL and XSD URL is received as input and the contents are validated using this service
     */ 
    public string XMLValidation(string xmlURL, string xsdURL)
    {       
        msg = "";
        /*
         * Create a schema set with the XSD URL
         */ 
        XmlSchemaSet schemaSet = new XmlSchemaSet();
        schemaSet.Add(null, xsdURL);
        /*
         * Assign validation type, schemas and eventhandler for readersetting accordingly
         */
        XmlReaderSettings readerSetting = new XmlReaderSettings();
        readerSetting.ValidationType = ValidationType.Schema;
        readerSetting.Schemas = schemaSet;
        readerSetting.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);
        /*
         * get XMLURLString using xmlreader 
         */
        XmlReader reader = XmlReader.Create(xmlURL, readerSetting);

        /*
         * read the contents and validate using xsd
         * if valid return valid else return invalid
         */ 
        flag = false;
        while (reader.Read());
        reader.Close();
        if (flag == false) { return ("XML is Valid"); }
        else { return ("XML is Invalid\n\n" + msg); }
    }

    /*
     * a validation event handler 
     * control reaches here in case of invalid xml
     */ 
    private static void ValidationCallBack(object sender, ValidationEventArgs e)
    {       
        flag = true;
        msg += "Validation Error: " + e.Message;
    }

    /*
     * Service to add new person using given values
     */ 
    public string AddNewPerson(string add)
    {
        FileStream fileStream = null;

        /*
         * Initialize all values to null
         */ 
        string first = null, last = null, Id = null, 
            password = null, encryption = null, work = null, 
            cell = null, category = null, provider = null;

        /*
         * Get the XML path
         */ 
        string fileName = "Person.xml";
        string filePath = Path.Combine(HttpRuntime.AppDomainAppPath, fileName);
        
        XmlTextWriter textWriter = null;
        /*
         * Split the string to get the values from the input
         */ 
        string[] elements = add.Split(',');

        /*
         * Assign values respectively
         */ 
        int count = 1;
        foreach (string element in elements)
        {
            switch(count)
            {
                case 1: first = element;
                    break;
                case 2: last = element;
                    break;
                case 3: Id = element;
                    break;
                case 4: password = element;
                    break;
                case 5: encryption = element;
                    break;
                case 6: work = element;
                    break;
                case 7: cell = element;
                    break;
                case 8: category = element;
                    break;
                case 9: provider = element;
                    break;
                default:
                    break;
            }
            count += 1;
        }

        /*
         * Check if the file exist or not
         */ 
        if (File.Exists(filePath))
        {
            try
            {
                /*
                 * If yes open the text writer and start creating a new person 
                 * with the values retrieved in the previous step.
                 */ 
                fileStream = new FileStream(filePath, FileMode.Append);
                textWriter = new XmlTextWriter(fileStream, Encoding.UTF8);
                textWriter.Formatting = Formatting.Indented;
                textWriter.WriteStartElement("Person");
                textWriter.WriteStartElement("Name");
                textWriter.WriteElementString("First", first);
                textWriter.WriteElementString("Last", last);
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("Credential");
                textWriter.WriteElementString("Id", Id);
                textWriter.WriteStartElement("Password");
                textWriter.WriteAttributeString("Encryption", encryption);
                textWriter.WriteString(password);
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("Phone");
                textWriter.WriteElementString("Work", work);
                textWriter.WriteStartElement("Cell");
                if (!provider.Equals("")){ textWriter.WriteAttributeString("Provider", provider); }
                textWriter.WriteString(cell);
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();
                textWriter.WriteElementString("Category", category);
                textWriter.WriteEndElement();
                textWriter.Close();
                fileStream.Close();
                writeContentsToXML();
                return "Status : Person appended successfully";
            }
            finally
            {
                textWriter.Close();
                fileStream.Close();
            }
        }
        else { return "Status : Append Failed"; }
    }

    /*
     * write the contents created in the previous step into the file 
     * present in the project folder
     */ 
    private void writeContentsToXML()
    {
        /*
         * Get the file name and get the tag that need to be replaced 
         * with new content
         */ 
        string fileName = "Person.xml";
        string endTag = "</Persons>";
        string filePath = Path.Combine(HttpRuntime.AppDomainAppPath, fileName);
        /*
         * Initialize the list to transfer all the contents into the list
         */ 
        List<string> xmlStringList = new List<string>();
        if (File.Exists(filePath))
        {
            using (StreamReader streamReader = File.OpenText(filePath))
            {
                while (!streamReader.EndOfStream)
                {
                    String s = streamReader.ReadLine();
                    if (!s.Equals(endTag)) { xmlStringList.Add(s); }
                }
                xmlStringList.Add(endTag);
                xmlStringList.Add("\n");
            }

            /*
             * convert the list into string and write into the file
             */ 
            File.WriteAllLines(filePath, xmlStringList.ToArray());
        }
    }
}
