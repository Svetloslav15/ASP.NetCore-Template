namespace AspNetCoreTemplate.Infrastructure.Models
{
    using AspNetCoreTemplate.Infrastructure.Models.Common;
    using Microsoft.AspNetCore.Identity;
    using System;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}