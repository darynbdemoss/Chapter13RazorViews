﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace Chapter13RazorViews.Models
{
    public class Event
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ContactEmail { get; set; }
        public string EventLocation { get; set; }
        public int NumberOfAttendees { get; set; }
        public EventCategory Category { get; set; }
        public int CategoryId { get; set; }
        public int Id { get; set; }
        
        public Event()       
        {            
        }
        

        public Event(string name, string description, string contactEmail, string eventLocation, int numberOfAttendees) 
        {
            Name = name;
            Description = description;
            ContactEmail = contactEmail;
            EventLocation = eventLocation;
            NumberOfAttendees = numberOfAttendees;            
        }

        public override string ToString()
        {
            return Name;
        }
        public override bool Equals(object obj)
        {
            return obj is Event @event &&
                   Id == @event.Id;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

    }
}
