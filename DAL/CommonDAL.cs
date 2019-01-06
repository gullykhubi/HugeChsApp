using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
namespace DAL
{
    public class CommonDAL
    {
        string strconn = ConfigurationSettings.AppSettings["ConnString"];
        public DataSet Get_MasterDetails()
        {
            try
            {
                SqlConnection con = new SqlConnection(strconn);
                con.Open();
                SqlCommand cmd = new SqlCommand("Proc_GetMasterDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter dp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                dp.Fill(ds);

                return ds;
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
                SqlConnection con = new SqlConnection(strconn);
                con.Open();
                SqlCommand cmd = new SqlCommand("Proc_MemberDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@flag", flag);
                cmd.Parameters.AddWithValue("@Sid", Sid);
                cmd.Parameters.AddWithValue("@Asset_No", Asset_No);
                cmd.Parameters.AddWithValue("@Floor", Floor);
                cmd.Parameters.AddWithValue("@Asset_Id", Asset_Id);
                SqlDataAdapter dp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                dp.Fill(ds);

                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


    }
}
