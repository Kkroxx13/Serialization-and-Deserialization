using System;
using System.Collections.Generic;
using System.Text;

namespace SerializationBinary
{
    [Serializable]
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string email { get; set; }


    }
}