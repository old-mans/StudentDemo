using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentDemo.Models;

namespace StudentDemo.Cont
{
    public class HomeController : Controller
    {
        private readonly IStudent _istudent;
        //使用构造函数注入的方式注入 istudent
        public HomeController(IStudent istudent)
        {
            _istudent = istudent;
        }
        public Student Index()
        {
            return _istudent.GetStudent(1);


            //return "MVC";
        }
        public Student Details()
        {
            return _istudent.GetStudent(1);


            //return "MVC";
        }
    }
}