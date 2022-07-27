using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Anket_Projesi_Ford_Otosan.Models
{
    public class AnketKaydetme
    {
        public int SQ_ANKET_ID { get; set; }
        public string CH_ANKET { get; set; }
        public DateTime DT_OLUS_TARIHI { get; set; }
        public DateTime DT_YAYIN_TARIHI { get; set; }
        public DateTime DT_BITIS_TARIHI { get; set; }
        public int? CD_OLUS_KISI { get; set; }
        public int? CD_GUNC_KISI { get; set; }
        public DateTime DT_GUNC_TARIHI { get; set; }
        public Nullable<bool> SW_DURUM { get; set; }
        public string CH_SECENEK { get; set; }
        public string CH_SORU { get; set; }

        public int SQ_IS_NO { get; set; }

        public int CD_REF_ID { get; set; }

        public string Cevaplar { get; set; }

        public int AnketSayac { get; set; }
        public int CevapSayac { get; set; }

    }

}