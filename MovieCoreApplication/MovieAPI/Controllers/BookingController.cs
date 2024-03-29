﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Business.Services;
using MovieApp.Entity;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        BookingService _bookingService;

        public BookingController(BookingService bookingService)
        {
            _bookingService = bookingService;   
        }


        [HttpGet("ShowBookingList")]
        public IActionResult ShowBookingList()
        {
            return Ok(_bookingService.showAllBooking());
        }

        [HttpPost("AddBooking")]
        public IActionResult AddBooking(BookingModel bookingModel)
        {
            return Ok(_bookingService.AddBooking(bookingModel));
        }

        [HttpGet("GetBookingById")]
        public IActionResult GetBookingById(int bookingId)
        {
            return Ok(_bookingService.GetBookingById(bookingId));
        }

        [HttpPut("UpdateBookingDetails")]
        public IActionResult UpdateBookingDetails([FromBody] BookingModel bookingModel)
        {
            _bookingService.UpdateBookingDetails(bookingModel);
            return Ok("Updated Successfully");
        }

    }
}
