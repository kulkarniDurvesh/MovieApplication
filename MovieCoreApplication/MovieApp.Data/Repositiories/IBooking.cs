using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Data.Repositiories
{
    public interface IBooking
    {
        string AddBooking(BookingModel bookingModel);

        object showAllBooking();
        object GetBookingById(int bookingId);
        string UpdateBookingDetails(BookingModel bookingModel);
    }
}
