using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BAL;
using System.Data;
using System.Web.Script.Serialization;

namespace HugeChsApp.Controllers
{
    public class MemberController : Controller
    {
        //
        // GET: /Member/
        CommonBAL objbal = new CommonBAL();
        public ActionResult Index()
        {
            return View();
        }

        public string Get_MemberDetails(string flag = "All", int Sid = 1, int Asset_No = 0, int Floor = 0, int Asset_Id = 0)
        {
            try
            {
                DataSet ds = objbal.Get_MemberDetails(flag, Sid, Asset_No, Floor, Asset_Id);
                Dictionary<string, object> objroute = new Dictionary<string, object>();
                List<object> objlst = new List<object>();
                if (ds != null)
                {
                    DataTable dtmember = ds.Tables[0];
                    for (int i = 0; i < dtmember.Rows.Count; i++)
                    {
                        Dictionary<string, string> objdic = new Dictionary<string, string>();
                        objdic.Add("Sid", dtmember.Rows[i]["Sid"].ToString());
                        objdic.Add("Asset_No", dtmember.Rows[i]["Asset_No"].ToString());
                        objdic.Add("Asset_Id", dtmember.Rows[i]["Asset_Id"].ToString());
                        objdic.Add("Floor_No", dtmember.Rows[i]["Floor_No"].ToString());
                        objdic.Add("Area_Sqft", dtmember.Rows[i]["Area_Sqft"].ToString());
                        objdic.Add("Name", dtmember.Rows[i]["Name"].ToString());
                        objdic.Add("Gender", dtmember.Rows[i]["Gender"].ToString());
                        objdic.Add("MobileNo", dtmember.Rows[i]["MobileNo"].ToString());
                        objdic.Add("Age", dtmember.Rows[i]["Age"].ToString());
                        objdic.Add("DOB", dtmember.Rows[i]["DOB"].ToString());
                        objlst.Add(objdic);
                    }
                }

                objroute.Add("Members", objlst);
                string myJsonString = (new JavaScriptSerializer()).Serialize(objroute);

                return myJsonString;
            }
            catch (Exception ex)
            {
                return "Exception:" + ex.ToString();
            }
        }

        public string Get_MemberLogin()
        {
            try
            {
                return "1";
            }
            catch (Exception ex)
            {
                return "";
            }
        }

    }
}
