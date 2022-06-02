using MovieApp.Data.Repositiories;
using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Business.Services
{
    public class BookingService
    {
        IBooking _ibooking;

        public BookingService(IBooking booking)
        {
                _ibooking = booking;
        }

        public string AddBooking(BookingModel bookingModel)
        { 
            return _ibooking.AddBooking(bookingModel);
        }

        public object showAllBooking()
        {
            return _ibooking.showAllBooking();
        }

    }
}
