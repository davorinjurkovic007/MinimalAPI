using System;
using System.Collections.Generic;

namespace DevNot21.Entities
{
    public partial class DbSecurityController
    {
        public DbSecurityController()
        {
            DbSecurityActions = new HashSet<DbSecurityAction>();
            DbSecurityUserActions = new HashSet<DbSecurityUserAction>();
            DbSecurityUserRoles = new HashSet<DbSecurityUserRole>();
        }

        public int IdSecurityController { get; set; }
        public string? ControllerName { get; set; }
        public bool? IsDeleted { get; set; }
        public int? CreUser { get; set; }
        public DateTime CreDate { get; set; }
        public int? ModUser { get; set; }
        public DateTime? ModDate { get; set; }
        public string? Client { get; set; }
        public string? ClientIp { get; set; }
        public bool Deleted { get; set; }

        public virtual ICollection<DbSecurityAction> DbSecurityActions { get; set; }
        public virtual ICollection<DbSecurityUserAction> DbSecurityUserActions { get; set; }
        public virtual ICollection<DbSecurityUserRole> DbSecurityUserRoles { get; set; }
    }
}
