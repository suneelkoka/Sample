//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sample.WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProjectPeople
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int PeopleId { get; set; }
        public string Description { get; set; }
    
        public virtual Person Person { get; set; }
        public virtual Project Project { get; set; }
    }
}
