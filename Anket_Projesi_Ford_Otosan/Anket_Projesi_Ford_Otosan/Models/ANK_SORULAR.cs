//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Anket_Projesi_Ford_Otosan.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ANK_SORULAR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ANK_SORULAR()
        {
            this.ANK_SECENEKLER = new HashSet<ANK_SECENEKLER>();
        }
    
        public int SQ_SORU_ID { get; set; }
        public Nullable<int> CD_ANKET_ID { get; set; }
        public string CH_SORU { get; set; }
        public System.DateTime DT_EKL_TARIHI { get; set; }
        public Nullable<int> CD_EKL_KISI { get; set; }
        public Nullable<int> CD_GUNC_KISI { get; set; }
        public Nullable<System.DateTime> DT_GUNC_TARIHI { get; set; }
        public Nullable<int> CD_REF_ID { get; set; }
    
        public virtual ANK_ANKETLER ANK_ANKETLER { get; set; }
        public virtual ANK_CALISANLAR ANK_CALISANLAR { get; set; }
        public virtual ANK_CALISANLAR ANK_CALISANLAR1 { get; set; }
        public virtual ANK_REFERANSLAR ANK_REFERANSLAR { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ANK_SECENEKLER> ANK_SECENEKLER { get; set; }
    }
}
