using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities.Base
{
    public abstract class Entity
    {
        [Required]
        public Guid Id { get; set; }
    }
}