using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CTS.BAL.Services;
using CTS.Models;
using CTS.DAL;
using CTS.DAL.Repositories;

namespace CTS.BAL.Services
{
    public class BookingService
    {

        private BookingRepository _iBookingRepository;

        public BookingService()
        {
            _iBookingRepository = new BookingRepository();
        }

        public IEnumerable<Booking_Master> Get_BookingsForGateOut(int PCustId, string PSearch = null)
        {
            return _iBookingRepository.Get_BookingsForGateOut(PCustId, PSearch);
        }

        public IEnumerable<Booking_Master> Get_RemainingBookings(string PCustId, string PSizeId, string PBookingId)
        {
            return _iBookingRepository.Get_RemainingBookings(PCustId, PSizeId, PBookingId);
        }
    }
}
