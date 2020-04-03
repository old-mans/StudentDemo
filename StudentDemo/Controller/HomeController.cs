using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentDemo.Models;

namespace StudentDemo.Cont
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _ilogger;
        private readonly IStudent _istudent;
        //使用构造函数注入的方式注入 istudent
        public HomeController(IStudent istudent/*， ILogger<HomeController> ilogger*/)
        {
            //_ilogger = ilogger;
            _istudent = istudent;
        }
        public Student Index()
        {
            //this._ilogger.LogWarning("qweqwe");
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