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
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class USER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USER()
        {
            this.HOADONs = new HashSet<HOADON>();
            this.PHIEUQUATANGs = new HashSet<PHIEUQUATANG>();
        }
    
        public int MaUser { get; set; }
        public double SoTienTK { get; set; }
        public int DiemThuong { get; set; }
        [Display(Name = "Enter Name")]
        [Required(ErrorMessage = "Name can not be blank")]
        public string TenUser { get; set; }
        [Display(Name = "Enter Email")]
        [Required(ErrorMessage = "Email can not be blank")]
        public string Email { get; set; }
        [Display(Name = "Enter Account")]
        [Required(ErrorMessage = "Account can not be blank")]
        public string TaiKhoan { get; set; }

        [Display(Name = "Enter Password")]
        [Required(ErrorMessage = "Password can not be blank")]
        [DataType(DataType.Password)]
        public string MatKhau { get; set; }

        [NotMapped]
        [Compare("MatKhau")]
        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Password does not match")]
        [DataType(DataType.Password)]
        public string ConfirmPass { get; set; }
        public string MaQuyen { get; set; }
        [NotMapped]
        public double Recharge { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADON> HOADONs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUQUATANG> PHIEUQUATANGs { get; set; }
        public virtual QUYEN QUYEN { get; set; }
    }
}