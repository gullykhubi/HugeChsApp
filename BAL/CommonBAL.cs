using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
namespace BAL
{
    public class CommonBAL
    {
        CommonDAL objdal = new CommonDAL();
        public DataSet Get_MasterDetails()
        {
            try
            {
                return objdal.Get_MasterDetails();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet Get_MemberDetails(string flag, int Sid, int Asset_No, int Floor, int Asset_Id)
        {
            try
            {
                return objdal.Get_MemberDetails(flag, Sid, Asset_No, Floor, Asset_Id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
