using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Anket_Projesi_Ford_Otosan.Models
{
    public class cevapbilgiler
    {
        public int SQ_CEVAP_ID { get; set; }
        public int CD_SECENEK_ID { get; set; }
        public int CD_SORU_ID { get; set; }
        public int CD_CEVAPLAYAN_KISI { get; set; }
        public string CH_BILGI { get; set; }
        public int CD_REF_ID { get; set; }

    }
}