//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SupportSystem333.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class user
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public user()
        {
            this.Comments = new HashSet<Comment>();
        }
    
        public int ID_user { get; set; }
        public int ID_suggestion { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public int ID_country { get; set; }
        public string phone { get; set; }
        public int ID_role { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public Nullable<bool> active { get; set; }
    
        public virtual country country { get; set; }
        public virtual role role { get; set; }
        public virtual suggestion suggestion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
