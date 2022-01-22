using System;
using System.Collections.Generic;

namespace DevNot21.Entities
{
    public partial class GnBolge
    {
        public GnBolge()
        {
            AbAbones = new HashSet<AbAbone>();
        }

        public int IdBolge { get; set; }
        public string BolgeKodu { get; set; } = null!;
        public string BolgeAdi { get; set; } = null!;
        public string? FirmaAdi { get; set; }
        public string? FirmaKisaAdi { get; set; }
        public string? Vkn { get; set; }
        public string? EfaturaIban { get; set; }

        public virtual ICollection<AbAbone> AbAbones { get; set; }
    }
}
