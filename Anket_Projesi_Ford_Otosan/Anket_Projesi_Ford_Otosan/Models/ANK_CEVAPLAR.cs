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
    
    public partial class ANK_CEVAPLAR
    {
        public int SQ_CEVAP_ID { get; set; }
        public Nullable<int> CD_SECENEK_ID { get; set; }
        public Nullable<int> CD_SORU_ID { get; set; }
        public Nullable<int> CD_CEVAPLAYAN_KISI { get; set; }
        public string CH_BILGI { get; set; }
        public Nullable<int> CD_NESNE_ID { get; set; }
    
        public virtual ANK_CALISANLAR ANK_CALISANLAR { get; set; }
        public virtual ANK_NESNELER ANK_NESNELER { get; set; }
    }
}
