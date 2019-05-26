using System;

namespace Awaoa.Core.Entity
{
    public interface IModification : IModification<Guid>
    {
    }

    public interface IModification<TPrimaryKeyOfUser>
    {
        DateTime ModifiedAt { get; set; }

        TPrimaryKeyOfUser ModifiedBy { get; set; }
    }
}
