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
    
    public partial class Employee_Master
    {
        public int EmpId { get; set; }
        public string Name { get; set; }
        public System.DateTime Date_Of_Birth { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public Nullable<int> Country { get; set; }
        public Nullable<int> State { get; set; }
        public Nullable<int> City { get; set; }
        public string EmailId { get; set; }
        public Nullable<int> RoleId { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<System.Guid> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModiefiedOn { get; set; }
        public Nullable<System.Guid> CreatedbY { get; set; }
        public Nullable<System.DateTime> Createdon { get; set; }
        public string Password { get; set; }
    
        public virtual City_Info City_Info { get; set; }
        public virtual Country_Info Country_Info { get; set; }
        public virtual RoleMaster RoleMaster { get; set; }
        public virtual State_info State_info { get; set; }
    }
}
