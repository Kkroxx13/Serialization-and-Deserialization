﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SerializationBinary
{
    public class DataSerializer
    {
        //Binary serialization and deserialization
        public void BinarySerialize(object data, string filePath)
        {
            FileStream fileStream;
            BinaryFormatter bf = new BinaryFormatter();
            if (File.Exists(filePath))
                File.Delete(filePath);
            fileStream = File.Create(filePath);
            bf.Serialize(fileStream, data);
            fileStream.Close();

        }
        public object BinaryDeserialize(string filePath)
        {
            object obj = null;

            FileStream fileStream;
            BinaryFormatter bf = new BinaryFormatter();
            if (File.Exists(filePath))
            {
                fileStream = File.OpenRead(filePath);
                obj = bf.Deserialize(fileStream);
                fileStream.Close();
            }
            return obj;
        }

        //XML Serialization and Deserialization

        public void XmlSerialize(Type dataType, object data, string filePath1)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(dataType);
            if (File.Exists(filePath1))
            {
                File.Delete(filePath1);
            }
            TextWriter writer = new StreamWriter(filePath1);
            xmlSerializer.Serialize(writer, data);
            writer.Close();

        }
        public object XmlDeserialize(Type dataType, string filePath1)
        {
            object obj = null;

            XmlSerializer xmlSerializer = new XmlSerializer(dataType);
            if (File.Exists(filePath1))
            {
                TextReader textReader = new StreamReader(filePath1);
                obj = xmlSerializer.Deserialize(textReader);
                textReader.Close();
            }
            return obj;
        }

        //Json Serialization and Deserialization

        public void JsonSerialize(object data, string filePath2)
        {
            JsonSerializer jsonSerializer = new JsonSerializer();
            if (File.Exists(filePath2))
                File.Delete(filePath2);

            StreamWriter sw = new StreamWriter(filePath2);
            JsonWriter jsonWriter = new JsonTextWriter(sw);

            jsonSerializer.Serialize(jsonWriter, data);
            jsonWriter.Close();
            sw.Close();
        }

        public object JsonDeserialize(Type dataType, string filePath2)
        {
            JObject obj = null;
            JsonSerializer jsonSerializer = new JsonSerializer();
            if (File.Exists(filePath2))
            {
                StreamReader sr = new StreamReader(filePath2);
                JsonReader jsonReader = new JsonTextReader(sr);
                obj = jsonSerializer.Deserialize(jsonReader) as JObject;
                jsonReader.Close();
                sr.Close();

            }
            return obj.ToObject(dataType);

        }
    }
}