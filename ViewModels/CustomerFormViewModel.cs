using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoRentalProject.Models;

namespace VideoRentalProject.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipType { get; set; }
        public Customer Customer { get; set; }
    }
}