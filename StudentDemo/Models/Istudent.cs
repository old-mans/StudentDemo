using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentDemo.Models
{
    public interface IStudent
    {
        Student GetStudent(int id);
    }
}
