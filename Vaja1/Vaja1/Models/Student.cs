using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Vaja1.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        [DisplayName("Ime")]
        public string StudentName { get; set; }
        [DisplayName("Starost")]
        public int Age { get; set; }
    }
}