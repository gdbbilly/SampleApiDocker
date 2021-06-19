using System;
using System.Collections.Generic;
using System.Text;

namespace SampleApiDocker.Entities
{
    public class EventEntitie : BaseEntitie
    {
        public string Name { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
    }
}
