//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pro_Admin.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class RoleMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RoleMaster()
        {
            this.Employee_Master = new HashSet<Employee_Master>();
        }
    
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public System.Guid Createdby { get; set; }
        public System.DateTime Createdon { get; set; }
        public bool isDelete { get; set; }
        public bool isActive { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employee_Master> Employee_Master { get; set; }
    }
}