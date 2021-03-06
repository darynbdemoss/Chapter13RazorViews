﻿using System.Collections.Generic;

namespace Chapter13RazorViews.Models
{
    public class EventCategory
    {
        
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Event> Events { get; set; }
        public EventCategory()
        {
        }

        public EventCategory(string name)
        {
            Name = name;
        }
    }
}
