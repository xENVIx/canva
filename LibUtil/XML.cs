
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LibUtil
{
    public static class XML
    {

        public static String SetFilePath { set { _filePath = value; _filePathSet = true; } }

        public static void SerializeAppDataXML(Type dataType, Object data)
        {
            try
            {
                string appDataLocalPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                string appName = $"{Process.GetCurrentProcess().ProcessName.Replace(" ", "_")}";

                String fileName = $"{dataType.Name.Replace(" ", "_")}.xml";



                String outputPath = Path.Combine(appDataLocalPath, appName, fileName);


                var serializer = new DataContractSerializer(dataType);
                using (var stream = new FileStream(outputPath, FileMode.Create))
                {
                    using (var writer = XmlWriter.Create(stream, new XmlWriterSettings { Indent = true, Encoding = Encoding.UTF8 }))
                    {
                        CleanObject(data);
                        serializer.WriteObject(writer, data);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static bool DeserializeAppDataXML(out Object data, Type dataType)
        {

            try
            {
                string appDataLocalPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                string appName = $"{Process.GetCurrentProcess().ProcessName.Replace(" ", "_")}";

                String fileName = $"{dataType.Name.Replace(" ", "_")}.xml";


                String inputPath = Path.Combine(appDataLocalPath, appName, fileName);

                if (!File.Exists(inputPath))
                {
                    data = new object();
                    return false;
                }

                var serializer = new DataContractSerializer(dataType);
                using (var stream = new FileStream(inputPath, FileMode.Open))
                {
                    using (var reader = XmlReader.Create(stream))
                    {
                        data = serializer.ReadObject(reader);
                    }
                }

            }
            catch (Exception ex)
            {

                throw;
            }

            return true;
        }


        public static void SerializeXML(Type dataType, Object data)
        {

            try
            {

                String outputPath = "";

                String fileName = $"{dataType.Name.Replace(" ", "_")}.xml";
                if (!_filePathSet)
                {
                    string appDataLocalPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    string appName = $"{Process.GetCurrentProcess().ProcessName.Replace(" ", "_")}";





                    outputPath = Path.Combine(appDataLocalPath, appName); //, fileName);
                }
                else outputPath = Path.Combine(_filePath); //, fileName);


                

                if (outputPath != "")
                {
                    try
                    {
                        if (!Directory.Exists(outputPath))
                        {
                            Directory.CreateDirectory(outputPath);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }

                outputPath = Path.Combine(outputPath, fileName);

                


                var serializer = new DataContractSerializer(dataType);
                using (var stream = new FileStream(outputPath, FileMode.Create))
                {
                    using (var writer = XmlWriter.Create(stream, new XmlWriterSettings { Indent = true, Encoding = Encoding.UTF8 }))
                    {
                        CleanObject(data);
                        serializer.WriteObject(writer, data);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private static void CleanObject(object obj)
        {
            if (obj == null) return;

            var type = obj.GetType();

            foreach (var property in type.GetProperties())
            {
                if (property.CanRead && property.CanWrite && property.PropertyType == typeof(string))
                {
                    string originalValue = (string)property.GetValue(obj);
                    if (!string.IsNullOrEmpty(originalValue))
                    {
                        string cleanedValue = RemoveInvalidXmlChars(originalValue);
                        property.SetValue(obj, cleanedValue);
                    }
                }
                else if (property.CanRead && property.CanWrite && typeof(System.Collections.IEnumerable).IsAssignableFrom(property.PropertyType))
                {
                    foreach (var item in (System.Collections.IEnumerable)property.GetValue(obj))
                    {
                        CleanObject(item);
                    }
                }
            }
        }

        private static string RemoveInvalidXmlChars(string text)
        {
            StringBuilder buffer = new StringBuilder(text.Length);
            foreach (char c in text)
            {
                if (XmlConvert.IsXmlChar(c)) // Ensures character is valid for XML
                {
                    buffer.Append(c);
                }
            }
            return buffer.ToString();
        }

        public static bool DeserializeXML(out Object data, Type dataType)
        {

            try
            {

                String inputPath = "";
                String fileName = $"{dataType.Name.Replace(" ", "_")}.xml";
                if (!_filePathSet)
                {
                    string appDataLocalPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    string appName = $"{Process.GetCurrentProcess().ProcessName.Replace(" ", "_")}";




                    inputPath = Path.Combine(appDataLocalPath, appName, fileName);
                }
                else inputPath = Path.Combine(_filePath, fileName);

                if (!File.Exists(inputPath))
                {
                    data = new object();
                    return false;
                }

                var serializer = new DataContractSerializer(dataType);
                using (var stream = new FileStream(inputPath, FileMode.Open))
                {
                    using (var reader = XmlReader.Create(stream))
                    {
                        data = serializer.ReadObject(reader);
                    }
                }

            }
            catch (Exception ex)
            {

                throw;
            }

            return true;
        }



        private static String _filePath = String.Empty;
        private static bool _filePathSet = false;

       


    }
}
