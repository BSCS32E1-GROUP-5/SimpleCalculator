using System;
using System.Web.Mvc;
using WebApplication32.Models;

namespace WebApplication32.Controllers
{
    public class CalcController : Controller
    {
        // GET: Calc
        public ActionResult Index()
        {
            return View(new calc());
        }

        [HttpPost]
        public ActionResult Index(calc c, string calculate)
        {
            if (calculate == "add")
            {
                c.tot = c.num1 + c.num2;
            }
            else if (calculate == "min")
            {
                c.tot = c.num1 - c.num2;
            }
            else if (calculate == "mul")
            {
                c.tot = c.num1 * c.num2;
            }
            else if (calculate == "div")
            {
                if (c.num2 != 0)
                {
                    c.tot = c.num1 / c.num2;
                }
                else
                {
                    ModelState.AddModelError("num2", "Cannot divide by zero.");
                    return View(c);
                }
            }
            else
            {
                ModelState.AddModelError("calculate", "Invalid calculation operation.");
                return View(c);
            }

            return View(c);
        }
    }
}
