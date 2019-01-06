using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BAL;
using System.Data;
using System.Collections;
using System.Web.Script.Serialization;

namespace HugeChsApp.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        CommonBAL objbal = new CommonBAL();
        public ActionResult Index()
        {
           // Get_MasterDetails();
            return View();
        }

        public string Get_MasterDetails()
        {
            try
            {
                DataSet ds = objbal.Get_MasterDetails();
                Dictionary<string, object> objroute = new Dictionary<string, object>();
                Dictionary<string, object> objroutechild = new Dictionary<string, object>();
                List<object> objlstsociety = new List<object>();
                List<object> objlstusertype = new List<object>();
                if (ds != null)
                {
                    DataTable dt_Society = ds.Tables[0];
                    DataTable dt_Usertype = ds.Tables[1];
                    for (int i = 0; i < dt_Society.Rows.Count; i++)
                    {
                        Dictionary<string, string> objdic = new Dictionary<string, string>();
                        objdic.Add("Sid", dt_Society.Rows[i]["Sid"].ToString());
                        objdic.Add("SName", dt_Society.Rows[i]["SName"].ToString());
                        objlstsociety.Add(objdic);
                    }

                    for (int i = 0; i < dt_Usertype.Rows.Count; i++)
                    {
                        Dictionary<string, string> objdic = new Dictionary<string, string>();
                        objdic.Add("Id", dt_Usertype.Rows[i]["Id"].ToString());
                        objdic.Add("UType", dt_Usertype.Rows[i]["UType"].ToString());
                        objlstusertype.Add(objdic);
                    }

                    objroutechild.Add("SocietyList", objlstsociety);
                    objroutechild.Add("UserTypeList", objlstusertype);
                }
                objroute.Add("MasterList", objroutechild);

                string myJsonString = (new JavaScriptSerializer()).Serialize(objroute);

                return myJsonString;
            }
            catch (Exception ex)
            {
                return "Exception :" + ex.ToString();
            }
        }


    }
}
