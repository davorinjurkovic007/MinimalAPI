using System;
using System.Collections.Generic;

namespace DevNot21.Entities
{
    public partial class RoleGroup
    {
        public RoleGroup()
        {
            Roles = new HashSet<Role>();
            UserRoles = new HashSet<UserRole>();
        }

        public int Id { get; set; }
        public string? GroupName { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
