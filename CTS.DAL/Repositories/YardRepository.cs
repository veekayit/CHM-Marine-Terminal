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
    public class YardRepository
    {
        string strcon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;


        #region CRUD
        public Int32 Save(string strXML)
        {
            int res;
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Save_Yard_Master_XML_New))
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

        public IEnumerable<Yard_Master> GetAll()
        {
            List<Yard_Master> _list = new List<Yard_Master>();
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Get_YardDetails))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {


                        while (rdr.Read())
                        {
                            Yard_Master _obj = new Yard_Master();
                            _obj.Yard_Id = Convert.ToInt32(rdr["Yard_Id"]);
                            _obj.Yard_Code = Convert.ToString(rdr["Yard_Code"]);
                            _obj.Yard_Name = Convert.ToString(rdr["Yard_Name"]);
                            _obj.Branch_Id = Convert.ToInt32(rdr["Branch_Id"]);

                            _obj.Branch_Master = new Branch_Master
                            {
                                Branch_Id = Convert.ToInt32(rdr["Branch_Id"]),
                                Branch_Name = Convert.ToString(rdr["Branch_Name"])
                            };


                            _list.Add(_obj);
                        }
                    }
                }
            }

            return _list;
        }

        public IEnumerable<Yard_Master> GetYardsForBranches(string pAllowBranches = null)
        {
            List<Yard_Master> _list = new List<Yard_Master>();
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Get_YardDetails))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (!string.IsNullOrEmpty(pAllowBranches))
                    {
                        cmd.Parameters.AddWithValue("@AllowBranchIds", pAllowBranches);
                    }
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {

                        while (rdr.Read())
                        {
                            Yard_Master _obj = new Yard_Master();
                            _obj.Yard_Id = Convert.ToInt32(rdr["Yard_Id"]);
                            _obj.Yard_Code = Convert.ToString(rdr["Yard_Code"]);
                            _obj.Yard_Name = Convert.ToString(rdr["Yard_Name"]);
                            _obj.Branch_Id = Convert.ToInt32(rdr["Branch_Id"]);

                            _obj.Branch_Master = new Branch_Master
                            {
                                Branch_Id = Convert.ToInt32(rdr["Branch_Id"]),
                                Branch_Name = Convert.ToString(rdr["Branch_Name"])
                            };


                            _list.Add(_obj);
                        }
                    }
                }
            }

            return _list;
        }

        public IEnumerable<Yard_Master> GetYardsForUser(string PUserid)
        {
            List<Yard_Master> _list = new List<Yard_Master>();
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Get_YardsForUser))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserId", PUserid);

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {

                        while (rdr.Read())
                        {
                            Yard_Master _obj = new Yard_Master();
                            _obj.Yard_Id = Convert.ToInt32(rdr["Yard_Id"]);
                            _obj.Yard_Code = Convert.ToString(rdr["Yard_Code"]);
                            _obj.Yard_Name = Convert.ToString(rdr["Yard_Name"]);
                            _obj.Branch_Id = Convert.ToInt32(rdr["Branch_Id"]);

                            //_obj.Branch_Master = new Branch_Master
                            //{
                            //    Branch_Id = Convert.ToInt32(rdr["Branch_Id"]),
                            //    Branch_Name = Convert.ToString(rdr["Branch_Name"])
                            //};


                            _list.Add(_obj);
                        }
                    }
                }
            }

            return _list;
        }
       
        public Yard_Master GetByID(int Id)
        {
            Yard_Master _obj = new Yard_Master();
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Get_YardDetails))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Yard_Id", Id);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        _obj.Yard_Id = Convert.ToInt32(rdr["Yard_Id"]);
                        _obj.Yard_Code = Convert.ToString(rdr["Yard_Code"]);
                        _obj.Yard_Name = Convert.ToString(rdr["Yard_Name"]);
                        _obj.Branch_Id = Convert.ToInt32(rdr["Branch_Id"]);

                        _obj.Branch_Master = new Branch_Master
                        {
                            Branch_Id = Convert.ToInt32(rdr["Branch_Id"]),
                            Branch_Name = Convert.ToString(rdr["Branch_Name"])
                        };
 

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
                using (SqlCommand cmd = new SqlCommand(Procedures._yardMasterDelete))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@YardId", Id);
                    res = cmd.ExecuteNonQuery();

                }
            }
            return res;
        }
        #endregion
    }
}
