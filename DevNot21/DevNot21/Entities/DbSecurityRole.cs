using System;
using System.Collections.Generic;

namespace DevNot21.Entities
{
    public partial class DbSecurityRole
    {
        public DbSecurityRole()
        {
            DbSecurityUserRoles = new HashSet<DbSecurityUserRole>();
            DbUser2017s = new HashSet<DbUser2017>();
            DbUser2018s = new HashSet<DbUser2018>();
            DbUser2019s = new HashSet<DbUser2019>();
            DbUser2s = new HashSet<DbUser2>();
            DbUsers = new HashSet<DbUser>();
        }

        public int IdSecurityRole { get; set; }
        public string SecurityRoleName { get; set; } = null!;
        public int? CreUser { get; set; }
        public DateTime CreDate { get; set; }
        public int? ModUser { get; set; }
        public DateTime? ModDate { get; set; }
        public string? Client { get; set; }
        public string? ClientIp { get; set; }
        public bool Deleted { get; set; }

        public virtual ICollection<DbSecurityUserRole> DbSecurityUserRoles { get; set; }
        public virtual ICollection<DbUser2017> DbUser2017s { get; set; }
        public virtual ICollection<DbUser2018> DbUser2018s { get; set; }
        public virtual ICollection<DbUser2019> DbUser2019s { get; set; }
        public virtual ICollection<DbUser2> DbUser2s { get; set; }
        public virtual ICollection<DbUser> DbUsers { get; set; }
    }
}
