//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AsoEticaret.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Uye
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Uye()
        {
            this.UyeAdres = new HashSet<UyeAdres>();
        }
    
        public int ID { get; set; }
        public string AdSoyad { get; set; }
        public string Email { get; set; }
        public string Sifre { get; set; }
        public string Telefon { get; set; }
        public string TC { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UyeAdres> UyeAdres { get; set; }
    }
}
