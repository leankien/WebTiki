//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebTiki.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SANPHAM
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public Nullable<decimal> GiaCu { get; set; }
        public Nullable<decimal> GiaMoi { get; set; }
        public string BaiViet { get; set; }
        public string TomTat { get; set; }
        public string Img { get; set; }
        public Nullable<int> DanhMucID { get; set; }
    
        public virtual DanhMuc DanhMuc { get; set; }
    }
}
