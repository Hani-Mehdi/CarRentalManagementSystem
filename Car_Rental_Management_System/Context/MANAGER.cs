//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Car_Rental_Management_System.Context
{
    using System;
    using System.Collections.Generic;
    
    public partial class MANAGER
    {
        public int M_ID { get; set; }
        public string M_NAME { get; set; }
        public int M_AGE { get; set; }
        public string M_CONTACT { get; set; }
        public string M_PASSWORD { get; set; }
        public Nullable<int> D_ID { get; set; }
    
        public virtual DEPARTMENT DEPARTMENT { get; set; }
    }
}
