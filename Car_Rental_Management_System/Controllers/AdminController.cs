using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Car_Rental_Management_System.Context;
using System.Data;
using System.Data.SqlClient; 

namespace Car_Rental_Management_System.Controllers
{
    public class AdminController : Controller
    {
        CarRentalManagementsystemEntities dbObj = new CarRentalManagementsystemEntities();

        public static bool loginCheck = false;
        public static string managerDept;

        // GET: Admin
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult LoginVerification(MANAGER manager)
        {
            var result = dbObj.MANAGERs.Where(x => x.M_CONTACT == manager.M_CONTACT && x.M_PASSWORD == manager.M_PASSWORD);


            if (result.Any())
            {
                loginCheck = true;
                managerDept = getDepartmentName(manager);
                managerDetail.managerName = result.First().M_NAME;

                if (managerDept == "INVENTORY")
                {
                    return View("DashboardInventory", result.First());
                }
                else
                {
                    return Content("abc");
                }
            }
            else
            {
                ModelState.AddModelError(nameof(MANAGER.M_CONTACT),"INVALID CONTACT OR PASSWORD");
                return View("Login");
            }
        }

        private string getDepartmentName(MANAGER manager)
        {
            string query = @"SELECT D.D_NAME 
                            FROM MANAGER M
                            INNER JOIN DEPARTMENT D ON D.D_ID = M.D_ID
                            WHERE M_CONTACT = '" + manager.M_CONTACT + "' " +
                            "AND M_PASSWORD = '" + manager.M_PASSWORD + "' ";

            SqlConnection con = new SqlConnection(@"Data Source=PIRANI\SQLEXPRESS;Initial Catalog=CarRentalManagementsystem;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            string deptName = (string)cmd.ExecuteScalar();
            con.Close();

            return deptName;
        }

        public ActionResult addCarMake()
        {
            var result = dbObj.CARMAKEs.ToList();
            return View(result);
        }

        public ActionResult addCarMakeInDb(CARMAKE cmake)
        {
            dbObj.CARMAKEs.Add(cmake);
            dbObj.SaveChanges();

            return RedirectToAction("addCarMake");
        }

        public ActionResult deleteCarMakeFromDb(int ID)
        {
            var result = dbObj.CARMAKEs.Where(x => x.CMAKE_ID == ID).First();

            dbObj.CARMAKEs.Remove(result);
            dbObj.SaveChanges();

            return RedirectToAction("addCarMake");
        }

        public ActionResult addCarType()
        {
            var result = dbObj.CARTYPEs.ToList();
            return View(result);
        }

        public ActionResult addCarTypeInDb(CARTYPE ctype)
        {
            dbObj.CARTYPEs.Add(ctype);
            dbObj.SaveChanges();

            return RedirectToAction("addCarType");
        }

        public ActionResult deleteCarTypeFromDb(int ID)
        {
            var result = dbObj.CARTYPEs.Where(x => x.CTYPE_ID == ID).First();

            dbObj.CARTYPEs.Remove(result);
            dbObj.SaveChanges();

            return RedirectToAction("addCarType");
        }

        public ActionResult DashboardInventory()
        {
            if (loginCheck == true)
            {
                return View(); 
            }
            else
            {
                return View("Login");
            }
        }
    }
}