using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VideoRentalProject.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }

        // add readonly field to be used in the validdaion (MinAge18IfAMember) so we dont have to use magic numberthere like 0 or 1
        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo = 1;
    }
}