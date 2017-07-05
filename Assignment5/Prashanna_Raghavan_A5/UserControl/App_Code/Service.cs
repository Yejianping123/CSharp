using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.IO;
using System.Web;
using System.Xml;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{
    /*
     * A service implementation of encryption function using DLL 
     */
    public string Encrypt(string plainText)
    {
        string cipherText = CryptoDLL.CryptoDLLClass.Encrypt(plainText);
        return cipherText;
    }

    /*
     * A service implementation of decryption function using DLL 
     */
    public string Decrypt(string cipherText)
    {
        string plainText = CryptoDLL.CryptoDLLClass.Decrypt(cipherText);
        return plainText;
    }

    /*
     * A function to write the users subsribed to the system into the XML 
     */
    private void saveUsersToXML()
    {
        /*
         * Get the file path of the XML file
         */ 
        string fileName = "AuthorizedUsers.xml";
        string filePath = Path.Combine(HttpRuntime.AppDomainAppPath, fileName);

        /*
         * Create a list to write the existing contents
         */ 
        List<string> XMLContents = new List<string>();
        if (File.Exists(filePath))
        {
            using (StreamReader streamReader = File.OpenText(filePath))
            {
                while (!streamReader.EndOfStream)
                {
                    String s = streamReader.ReadLine(); 
                    if (!s.Equals("</Users>")) { XMLContents.Add(s); }
                }
                XMLContents.Add("</Users>");
                XMLContents.Add("\n");
            }
            /*
             * Write all users the list into the xml 
             */
            File.WriteAllLines(filePath, XMLContents.ToArray());
        }
    }

    /*
     * A service implementation to register a user with username, password and confirm password
     */ 
    public string RegisterUser(string username, string password, string confirmPassword)
    {
        XmlTextReader xmlReader = null;
        FileStream fileStream = null;
        XmlTextWriter xmlWriter = null;

        /*
         * Get the path of the XML file
         */ 
        string fileName = "AuthorizedUsers.xml";
        string filePath = Path.Combine(HttpRuntime.AppDomainAppPath, fileName);

        /*
         * Encrypt the given password before writing
         */
        string cipherPassword = Encrypt(password);

        /*
         * If conditions mismatch throw appropriate errors
         */
        if (password != confirmPassword) { return "Passwords mismatch."; }
        else if (username == password) { return "Choose a different password"; }

        try
        {
            /*
             * create a xmlTextReader to create an xml entry
             */ 
            xmlReader = new XmlTextReader(filePath);
            xmlReader.WhitespaceHandling = WhitespaceHandling.None;

            /*
             * check for duplicates
             */ 
            while (xmlReader.Read())
            {
                if (xmlReader.Value == username) { return "Username exists"; }
            }

            if (xmlReader != null) { xmlReader.Close(); }

            /*
             * open file stream and add contents
             */
            fileStream = new FileStream(filePath, FileMode.Append);    
            fileStream.Lock(0, 0);
            xmlWriter = new XmlTextWriter(fileStream, Encoding.UTF8);
            xmlWriter.Formatting = Formatting.Indented;
            xmlWriter.WriteStartElement("User");
            xmlWriter.WriteElementString("Username", username);
            xmlWriter.WriteElementString("Password", cipherPassword);
            xmlWriter.WriteElementString("Role", "Member");
            xmlWriter.WriteEndElement();
            xmlWriter.Close();
            fileStream.Close();
            /*
             * write the contents into XML and return success message
             */ 
            saveUsersToXML();
            return "Registration Successful";
        }
        finally
        {
            /*
             * close the reader and write if open
             */ 
            if (xmlWriter != null) { xmlWriter.Close(); }
            if (xmlReader != null) { xmlReader.Close(); }
        }

        return "Registration Failed";
    }

    /*
     * A service implemetation to authenticate user while login
     */ 
    public string AuthenticateUser(string username, string password)
    {
        XmlTextReader xmlReader = null;

        /*
         * Get the xml file path
         */ 
        string fileName = "AuthorizedUsers.xml";
        string filePath = Path.Combine(HttpRuntime.AppDomainAppPath, fileName);
        String value = null;
        String key = null;

        /*
         * Get the encrypted password
         */ 
        string cipherPassword = Encrypt(password);
        String input = username + " " + cipherPassword;
        string output = null;
        bool isValidated = false;

        /*
         * Check for empty string values
         */ 
        if (username == null || password == null) { return "Username or Password cannot be blank"; }

        try
        {
            xmlReader = new XmlTextReader(filePath);
            xmlReader.WhitespaceHandling = WhitespaceHandling.None;
            /*
             * Check for the matching record in the xml file
             */ 
            while (xmlReader.Read())
            {
                if (xmlReader.NodeType.ToString().Equals("Element"))
                {
                    key = xmlReader.Name.ToString();
                    value = null;
                }
                else if (xmlReader.Value != "")
                {
                    value = xmlReader.Value;
                    if (key == "Username") { output = value; }
                    else if (key == "Password")
                    {
                        output = output + " " + value;
                        if (input == output)
                        {
                            isValidated = true;
                            xmlReader.Read();
                            xmlReader.Read();
                            xmlReader.Read();
                            string role = xmlReader.Value;
                            return "Validation Successful-" + role;
                        }
                        output = null;
                    }
                    key = null;
                    value = null;
                }
            }

            /*
             * close the reader if open and return failure if the record does not match
             */ 
            if (xmlReader != null) { xmlReader.Close(); }
            if (isValidated == false) { return "Validation Failed-"; }
        }
        finally { xmlReader.Close(); }
        return "Failure";
    }
}
