using MovieApp.Data.DataConnection;
using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieApp.Data.Repositiories
{
    public class Booking : IBooking
    {
        MovieDbContext _movieDbContext;

        public Booking(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;   
        }

        public string AddBooking(BookingModel bookingModel)
        {
            _movieDbContext.bookingModels.Add(bookingModel);
            _movieDbContext.SaveChanges();
            return "Tickect Booked Successfully";
        }

        public object GetBookingById(int bookingId)
        {
          var foundBooking = _movieDbContext.bookingModels.Find(bookingId);
            if (foundBooking != null)
            {
                return foundBooking;
            }
            else
            {
                return "Booking Not Found";
            }
            
        }

        public object showAllBooking()
        {
            List<BookingModel> bookingList= _movieDbContext.bookingModels.ToList();
            return bookingList;
        }

        public string UpdateBookingDetails(BookingModel bookingModel)
        {
            string msg = "";
            _movieDbContext.Entry(bookingModel).State =Microsoft.EntityFrameworkCore.EntityState.Modified;
            _movieDbContext.SaveChanges();
            msg = "Updatation Completed";
            return msg;
        }
    }
}
