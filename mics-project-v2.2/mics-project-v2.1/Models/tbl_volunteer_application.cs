//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace mics_project_v2._1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class tbl_volunteer_application
    {
        public int Id { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Please provide your name")]
        public string full_name { get; set; }

        [Range(18, 70, ErrorMessage = "Your age must 18 to 70")]
        [Display(Name = "Age")]
        [Required(ErrorMessage = "Please provide your age")]
        public Nullable<int> age { get; set; }

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Please provide your gender")]
        public string gender { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Please provide your address")]
        public string address { get; set; }

        [Display(Name = "Date")]
        public Nullable<System.DateTime> date { get; set; }
        public Nullable<byte> Is_agree { get; set; }

        [Display(Name = "Application")]
        public Nullable<int> posting_id { get; set; }
    
        public virtual tbl_volunteer_posting tbl_volunteer_posting { get; set; }
    }
}
