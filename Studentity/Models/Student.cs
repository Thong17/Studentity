using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Studentity.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}