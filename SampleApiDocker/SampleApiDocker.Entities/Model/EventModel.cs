using System;
using System.Collections.Generic;
using System.Text;

namespace SampleApiDocker.Entities.Model
{
    public class EventModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
    }
}
