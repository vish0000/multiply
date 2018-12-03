using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Multiply.Models;

namespace Multiply.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

       [HttpPost]
       public IActionResult multiplyPost(string inputData, string separate)
        {
            int output = multiply(inputData, separate);
            ViewData["Output"] = output;
            return View("Index");
        }

        public int multiply(string data, string separate)
        {
            var separatedData = data.Split(separate);
            if (0 == separatedData.Count())
            {
                return 0;
            }

            List<int> separatedUIntData = new List<int>();

            foreach (var stringdata in separatedData)
            {
                int i = 0;
                var intvalue = 0;
                if (Int32.TryParse(stringdata, out intvalue))
                {
                    separatedUIntData.Add(intvalue);
                    i++;
                }
                else
                {
                    ViewData["errorMessage"] = "you enter some wrong string";
                }
            }
            int output = 1;
            if (separatedUIntData == null)
            {
                return 0;
            }
            else
            {
                switch (separatedUIntData.Count())
                {
                    case 0: return 0;

                    case 1: return separatedUIntData[0];

                    default:
                         foreach (var intData in separatedUIntData)
                        {
                            output *= intData;
                        }
                        return output;

                }
            }
        }
    }
}
