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
    
    public partial class tbl_admin
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_admin()
        {
            this.tbl_newsletter = new HashSet<tbl_newsletter>();
            this.tbl_primary_nav = new HashSet<tbl_primary_nav>();
            this.tbl_volunteer_posting = new HashSet<tbl_volunteer_posting>();
            this.tbl_volunteer_posting1 = new HashSet<tbl_volunteer_posting>();
            this.tbl_page = new HashSet<tbl_page>();
        }
    
        public int Id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string password { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_newsletter> tbl_newsletter { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_primary_nav> tbl_primary_nav { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_volunteer_posting> tbl_volunteer_posting { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_volunteer_posting> tbl_volunteer_posting1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_page> tbl_page { get; set; }
    }
}
