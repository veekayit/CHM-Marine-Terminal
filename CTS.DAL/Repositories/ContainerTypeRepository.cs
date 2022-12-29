using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using CTS.Models;

namespace CTS.DAL.Repositories
{
    public class ContainerTypeRepository
    {

        string strcon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;


        #region CRUD
        public Int32 Save(string strXML)
        {
            int res;
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Save_Container_TypeMaster_XML_New))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StrXML", strXML);
                    res = cmd.ExecuteNonQuery();

                }
            }

            return res;
        }

        public IEnumerable<Container_Type_Master> GetAll()
        {
            List<Container_Type_Master> _list = new List<Container_Type_Master>();
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Get_ContainerTypeDetails))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            Container_Type_Master _obj = new Container_Type_Master();
                            _obj.Container_Type_Id = Convert.ToInt32(rdr["Container_Type_Id"]);
                            _obj.Container_Type = Convert.ToString(rdr["Container_Type"]);

                            _list.Add(_obj);
                        }
                    }
                }
            }

            return _list;
        }

        public Container_Type_Master GetByID(int Id)
        {
            Container_Type_Master _obj = new Container_Type_Master();
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Get_ContainerTypeDetails))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Container_Type_Id", Id);
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            _obj.Container_Type_Id = Convert.ToInt32(rdr["Container_Type_Id"]);
                            _obj.Container_Type = Convert.ToString(rdr["Container_Type"]);


                        }
                    }
                }
            }


            return _obj;
        }

        public int Delete(int Id)
        {
            int res = 0;
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._ContainerTypeDelete))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Container_Type_Id", Id);
                    res = cmd.ExecuteNonQuery();

                }
            }
            return res;
        }
        #endregion
    }
}
