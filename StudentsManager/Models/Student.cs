using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentsManager.Models
{
    public class Student
    {
        //Student`s Id
        public virtual int StudentId { get; set; }

        //Student`s name
        [DisplayName("Student`s Name")]
        public virtual string Name { get; set; }

        //Student`s surname
        [DisplayName("Student`s Surname")]
        public virtual string Surname { get; set; }

        //Group number
        [DisplayName("Group Number")]
        public virtual int GroupId { get; set; }

        //Course name
        [DisplayName("Course")]
        public virtual int Course { get; set; }

        //Student`s grade
        [DisplayName("Grade")]
        public virtual int Grade { get; set; }
    }
}