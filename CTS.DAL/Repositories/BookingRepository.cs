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
    public class BookingRepository
    {

        string strcon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;


        public IEnumerable<Booking_Master> Get_BookingsForGateOut(int PCustId, string PSearch = null)
        {
            List<Booking_Master> _list = new List<Booking_Master>();
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Get_Bookings_ForGateOut))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CustomerId", PCustId);
                    if (!string.IsNullOrEmpty(PSearch)) cmd.Parameters.AddWithValue("@BookingNo", PSearch);
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {

                        while (rdr.Read())
                        {
                            Booking_Master _obj = new Booking_Master();
                            _obj.Booking_ID = (long)(rdr["Booking_ID"]);
                            _obj.BookingNo = rdr["BookingNo"].ToString();

                            _list.Add(_obj);
                        }
                    }
                }
            }

            return _list;
        }



        public IEnumerable<Booking_Master> Get_RemainingBookings(string PCustId, string PSizeId, string PBookingId)
        {
            List<Booking_Master> _list = new List<Booking_Master>();
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand(Procedures._Get_Remaining_Bookings))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CustomerId", PCustId);
                    cmd.Parameters.AddWithValue("@SizeId", PSizeId);
                    cmd.Parameters.AddWithValue("@BookingId", PBookingId);

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {

                        while (rdr.Read())
                        {
                            Booking_Master _obj = new Booking_Master();
                            _obj.Booking_ID = (long)(rdr["Booking_ID"]);
                            _obj.BookingNo = (rdr["Booking_ID"]).ToString();

                            _obj.Booking_Master_Sub = new Booking_Master_Sub
                            {
                                Booking_Sub_Id = (long)(rdr["Booking_Sub_Id"]),
                                Cont_SizeId = (int)(rdr["Contsize_Id"]),
                                TotalNo = (int)(rdr["TotalNo"]),
                                Balance = (int)(rdr["Balance"]),
                            };

                            _list.Add(_obj);
                        }
                    }
                }
            }

            return _list;
        }
    }
}
