using System;
using System.Collections.Generic;

namespace DevNot21.Entities
{
    public partial class GnSozlesmeTipi
    {
        public GnSozlesmeTipi()
        {
            AbAbones = new HashSet<AbAbone>();
        }

        public int IdSozlesmeTipi { get; set; }
        public string SozlesmeTipiAdi { get; set; } = null!;
        public string SozlesmeTipiKodu { get; set; } = null!;

        public virtual ICollection<AbAbone> AbAbones { get; set; }
    }
}
