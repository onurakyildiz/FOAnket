﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Anket_Projesi_Ford_Otosan.Models
{
    public class Anket
    {
        public Tuple<List< ANK_ANKETLER>,List<ANK_SORULAR>> AnketList { get; set; }

        public int SQ_ANKET_ID { get; set; }

        public string CH_ANKET { get; set; }
        public int SQ_SORU_ID { get; set; }
        public string CH_SORU { get; set; }

    }
}