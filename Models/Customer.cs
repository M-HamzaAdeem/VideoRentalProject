using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VideoRentalProject.Models
{
    public class Customer
    { 
        public int Id { get; set; } 

        [Required(ErrorMessage ="Pleae Enter Customer Name")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubsceibedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        [Display(Name = "Date of Birth")]
        [MinAge18IfAMember] 
        public DateTime? Birthday { get; set; }
    } 
}