using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentDemo.Models
{
    public class MoryStudent : IStudent
    {
        private List<Student> _students;

        public MoryStudent()
        {
            _students = new List<Student>()
            {
                new Student(){id=1,name="张三",classname="一年级"},
                new Student (){id=2,name="李四",classname="二年级"},
                new Student (){id=3,name="王五",classname="三年级"}
            };
        }

        public Student GetStudent(int id)
        {
            return _students.FirstOrDefault(a => a.id == id);
        }
    }
}
