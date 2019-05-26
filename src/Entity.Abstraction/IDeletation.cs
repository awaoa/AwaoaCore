using System;

namespace Awaoa.Core.Entity
{
    public interface IDeletation: IDeletation<Guid>
    {
    }

    public interface IDeletation<TPrimaryKeyOfUser> : ISoftDeletation
    {
        DateTime? DeletedAt { get; set; }

        TPrimaryKeyOfUser DeletedBy { get; set; }
    }
}
