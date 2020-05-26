using System;
using System.Collections.Generic;
using CinemaWatch.Models;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CinemaWatch.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public byte MembershipTypeId { get; set; }

        //[Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }
    }
}