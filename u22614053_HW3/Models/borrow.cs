//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace u22614053_HW3.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class borrow
    {
        public int borrowId { get; set; }
        public Nullable<int> studentId { get; set; }
        public Nullable<int> bookId { get; set; }
        public Nullable<System.DateTime> takenDate { get; set; }
        public Nullable<System.DateTime> broughtDate { get; set; }
    
        public virtual book book { get; set; }
        public virtual student student { get; set; }
    }
}
