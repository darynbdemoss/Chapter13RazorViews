﻿using System;
using System.ComponentModel.DataAnnotations;
using Chapter13RazorViews.Controllers;

namespace Chapter13RazorViews.ViewModels
{
    public class AddEventViewModel
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a description for your event.")]
        [StringLength(500, ErrorMessage = "Description is too long.")]
        public string Description { get; set; }

        [EmailAddress]
        public string ContactEmail { get; set; }

        [Required(ErrorMessage = "Event Location is required.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Event must be between 2 and 50 characters.")]
        public string EventLocation { get; set; }

        [Required(ErrorMessage = "NumberOfAttendees is required.")]
        [Range(0, 100000, ErrorMessage = "Number of Attendees must be between 0 and 100,000.")]
        public int NumberOfAttendees { get; set; }


    }
}
