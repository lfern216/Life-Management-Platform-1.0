//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LifeManagement.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public System.DateTime DOB { get; set; }
        public int RoleId { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public System.DateTime DateCreated { get; set; }
    
        public virtual Role Role { get; set; }
    }
}
