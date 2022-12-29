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
    public class ContainerSizeRepository
    {
        string strcon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;


        #region CRUD
        public Int32 Save(string strXML)
        {
            int res;
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Save_Container_SizeMaster_XML_New))
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

        public IEnumerable<Cont_Size_Master> GetAll()
        {
            List<Cont_Size_Master> _list = new List<Cont_Size_Master>();
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Get_ContainerSizes))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            Cont_Size_Master _obj = new Cont_Size_Master();
                            _obj.Contsize_Id = Convert.ToInt32(rdr["Contsize_Id"]);
                            _obj.Cont_Size = Convert.ToString(rdr["Cont_Size"]);
                            _obj.Container_Type_Id = Convert.ToInt32(rdr["Container_Type_Id"]);
                            _obj.Is_Reefer = Convert.ToBoolean(rdr["Is_Reefer"]);
                            _obj.oth_size = Convert.ToString(rdr["oth_size"]);
                            _obj.ISO = Convert.ToString(rdr["ISO"]);
                            _obj.Client_Group_Id = Convert.ToInt32(rdr["Client_Group_Id"]);

                            _obj.Client_Group = new Client_Group
                            {
                                Client_Group_Id = Convert.ToInt32(rdr["Client_Group_Id"]),
                                Client_Group_Name = Convert.ToString(rdr["Client_Group_Name"])
                            };

                            _obj.Container_Type_Master = new Container_Type_Master
                            {
                                Container_Type_Id = Convert.ToInt32(rdr["Container_Type_Id"]),
                                Container_Type = Convert.ToString(rdr["Container_Type"])
                            };


                            _list.Add(_obj);
                        }
                    }
                }
            }

            return _list;
        }




        public Cont_Size_Master GetByID(int Id)
        {
            Cont_Size_Master _obj = new Cont_Size_Master();
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Get_ContainerSizes))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_SizeId", Id);
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            _obj.Contsize_Id = Convert.ToInt32(rdr["Contsize_Id"]);
                            _obj.Cont_Size = Convert.ToString(rdr["Cont_Size"]);
                            _obj.Container_Type_Id = Convert.ToInt32(rdr["Container_Type_Id"]);
                            _obj.Is_Reefer = Convert.ToBoolean(rdr["Is_Reefer"]);
                            _obj.oth_size = Convert.ToString(rdr["oth_size"]);
                            _obj.ISO = Convert.ToString(rdr["ISO"]);
                            _obj.Client_Group_Id = Convert.ToInt32(rdr["Client_Group_Id"]);

                            _obj.Client_Group = new Client_Group
                            {
                                Client_Group_Id = Convert.ToInt32(rdr["Client_Group_Id"]),
                                Client_Group_Name = Convert.ToString(rdr["Client_Group_Name"])
                            };

                            _obj.Container_Type_Master = new Container_Type_Master
                            {
                                Container_Type_Id = Convert.ToInt32(rdr["Container_Type_Id"]),
                                Container_Type = Convert.ToString(rdr["Container_Type"])
                            };


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
                using (SqlCommand cmd = new SqlCommand(Procedures._ContSizeDelete))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_Contsize_Id", Id);
                    res = cmd.ExecuteNonQuery();

                }
            }
            return res;
        }
        #endregion
    }
}
