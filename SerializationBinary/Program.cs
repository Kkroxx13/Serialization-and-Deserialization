using System;
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
    class Program
    {
        static void Main(string[] args)
        {


            string filePath = "data.bin";
            string filePath1 = "data1.xml";
            string filePath2 = "data2.json";

            DataSerializer dataSerializer = new DataSerializer();

            Person p = null;
            Person p1 = null;
            Person p2 = null;


            bool loopbreak = true;
            while (loopbreak)
            {
                Console.WriteLine("1.Implement Binary Serialization and Deserialization");
                Console.WriteLine("2.Implement XML Serialization and Deserialization");
                Console.WriteLine("3.Implement JSON Serialization and Deserialization");
                Console.WriteLine("Select your Choice");
                int input = int.Parse(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        Person person = new Person();
                        Console.WriteLine("Enter the First Name");
                        person.FirstName = (Console.ReadLine());
                        Console.WriteLine("Enter Last Name");
                        person.LastName = Console.ReadLine();
                        Console.WriteLine("Enter Address");
                        person.Address = Console.ReadLine();
                        Console.WriteLine("Enter Email");
                        person.email = Console.ReadLine();
                        


                        dataSerializer.BinarySerialize(person, filePath);
                        p = dataSerializer.BinaryDeserialize(filePath) as Person;
                        Console.WriteLine();
                        Console.WriteLine("First Name :" + person.FirstName);
                        Console.WriteLine("Last Name :" + person.LastName);
                        Console.WriteLine("Address  :" + person.Address);
                        Console.WriteLine("Email:" + person.email);
                        Console.WriteLine();
                        break;

                    case 2:
                        Person person1 = new Person();
                        Console.WriteLine("Enter the firstName");
                        person1.FirstName = (Console.ReadLine());
                        Console.WriteLine("Enter Last Name");
                        person1.LastName = Console.ReadLine();
                        Console.WriteLine("Enter Address");
                        person1.Address = Console.ReadLine();
                        Console.WriteLine("Enter Email");
                        person1.email = Console.ReadLine();

                        dataSerializer.XmlSerialize(typeof(Person), person1, filePath1);
                        p1 = dataSerializer.XmlDeserialize(typeof(Person), filePath1) as Person;
                        Console.WriteLine();
                        Console.WriteLine("First Name :" + person1.FirstName);
                        Console.WriteLine("Last Name :" + person1.LastName);
                        Console.WriteLine("Address  :" + person1.Address);
                        Console.WriteLine("Email:" + person1.email);
                        Console.WriteLine();
                        break;

                    case 3:

                        Person person2 = new Person();
                        Console.WriteLine("Enter the firstName");
                        person2.FirstName = (Console.ReadLine());
                        Console.WriteLine("Enter Last Name");
                        person2.LastName = Console.ReadLine();
                        Console.WriteLine("Enter Address");
                        person2.Address = Console.ReadLine();
                        Console.WriteLine("Enter Email");
                        person2.email = Console.ReadLine();

                        dataSerializer.JsonSerialize(person2, filePath2);
                        p2 = dataSerializer.JsonDeserialize(typeof(Person), filePath2) as Person;
                        Console.WriteLine();
                        Console.WriteLine("First Name :" + person2.FirstName);
                        Console.WriteLine("Last Name :" + person2.LastName);
                        Console.WriteLine("Address  :" + person2.Address);
                        Console.WriteLine("Email:" + person2.email);
                        Console.WriteLine();

                        break;

                    default:
                        Console.WriteLine("Please enter valid choice");
                        loopbreak = false;
                        break;
                }

                if (loopbreak)
                    Console.WriteLine("Please enter valid option");
            }

        }
    }


}