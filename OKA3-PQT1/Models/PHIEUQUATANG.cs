//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OKA3_PQT1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PHIEUQUATANG
    {
        public int MaPhieu { get; set; }
        public int MaUser { get; set; }
        public int MaCTPhieu { get; set; }
        public int SoLuongPhieu { get; set; }
    
        public virtual CT_PHIEUQUATANG CT_PHIEUQUATANG { get; set; }
        public virtual USER USER { get; set; }
    }
}