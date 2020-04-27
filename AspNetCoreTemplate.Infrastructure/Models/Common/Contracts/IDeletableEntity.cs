namespace AspNetCoreTemplate.Infrastructure.Models.Common
{
    using System;

    public interface IDeletableEntity
    {
        bool IsDeleted { get; set; }

        DateTime? DeletedOn { get; set; }
    }
}