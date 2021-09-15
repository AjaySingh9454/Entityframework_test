using System;
using System.Collections.Generic;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Abp.Domain.Entities;
using Entityframeworktest.Models;
using Newtonsoft.Json.Linq;

namespace Entityframeworktest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            EntityFrameWorkTestEntities entities = new EntityFrameWorkTestEntities();
            UserMaster uobj = new UserMaster();
            try
            {
                string strId= Request.Params["Id"];
                tbl_UserMaster uu = new tbl_UserMaster();
                if (!string.IsNullOrEmpty(strId))
                {
                    int idd = Convert.ToInt32(strId);
                    uu = entities.tbl_UserMaster.FirstOrDefault(u => u.EmployeeId == idd);
                    uobj.EmployeeId = idd;
                    uobj.EmployeeName = uu.EmployeeName;
                    uobj.EmployeeDob = uu.EmployeeDob;
                    uobj.Gender = uu.Gender;
                    uobj.Address = uu.Address;
                    uobj.State = uu.State; 
                }


            }
            catch (Exception ex) { }
            
            return View(uobj);
        }

        public ActionResult About()
        {
            EntityFrameWorkTestEntities entities = new EntityFrameWorkTestEntities();
            ViewBag.Message = "Your application description page.";
            List<tbl_UserMaster> list = entities.tbl_UserMaster.ToList<tbl_UserMaster>();
            return View(list);
        }

       [HttpPost]
       public string SaveOrUpdate(string data)
        {
            EntityFrameWorkTestEntities entities = new EntityFrameWorkTestEntities();
            tbl_UserMaster userMaster = new tbl_UserMaster();
            try
            {

               
                JObject jobj = JObject.Parse(data);
                int idd = jobj.GetValue("EmployeeId").Value<int>();
                if (idd>0)
                {
                   userMaster=entities.tbl_UserMaster.Where(x => x.EmployeeId == idd).FirstOrDefault();
                }
                userMaster.EmployeeName = jobj.GetValue("EmployeeName").Value<string>();
                userMaster.EmployeeDob = Convert.ToDateTime(jobj.GetValue("EmployeeDob").Value<string>());
                userMaster.Gender = jobj.GetValue("Gender").Value<string>();
                userMaster.Address = jobj.GetValue("Address").Value<string>();
                userMaster.State = jobj.GetValue("State").Value<string>();
                userMaster.CreatedBy = "ajay@gmail.com";
                userMaster.ModifiedBy = "ajay@gmail.com";
                userMaster.CreatedDate = Convert.ToDateTime( DateTime.Now.ToString("yyyy-MM-dd"));
                userMaster.ModifiedDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                userMaster.IsActive = true;

                if(idd<=0)
                entities.tbl_UserMaster.Add(userMaster);
                entities.SaveChanges();
            }
            catch(Exception ex)
            {
                return ex.Message;
            }                          
            return "Record submitted successfully!!";
        }

        [HttpPost]
        public string DeleteUser(string data)
        {
            EntityFrameWorkTestEntities entities = new EntityFrameWorkTestEntities();
            try
            {
                JObject jobj = JObject.Parse(data);
                tbl_UserMaster userObj = new tbl_UserMaster();
                int id = jobj.GetValue("Id").Value<int>();
                if (id > 0)
                    userObj=entities.tbl_UserMaster.FirstOrDefault(u => u.EmployeeId == id );

                entities.tbl_UserMaster.Remove(userObj);
                entities.SaveChanges();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "Record deleted successfully!!";
        }
        
    }
}