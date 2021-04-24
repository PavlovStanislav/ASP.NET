using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace StudentsManager.Models
{
    public class StudentsDbInitializer : DropCreateDatabaseIfModelChanges<StudentContext>
    {
        protected override void Seed(StudentContext context)
        {
            context.Students.Add(new Student { Surname = "Ivanov", Name = "Ivan", GroupId = 1111, Course = 1, Grade = 3 });
            context.Students.Add(new Student { Surname = "Pavlov", Name = "Pavel", GroupId = 2222, Course = 2, Grade = 4 });
            context.Students.Add(new Student { Surname = "Semenov", Name = "Semen", GroupId = 3333, Course = 3, Grade = 5 });

            base.Seed(context);
        }
    }
}