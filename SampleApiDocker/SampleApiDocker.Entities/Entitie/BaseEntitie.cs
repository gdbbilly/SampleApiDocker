using System;
using System.ComponentModel.DataAnnotations;

namespace SampleApiDocker.Entities
{
    public class BaseEntitie
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime DateInserted { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
