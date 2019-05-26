using System;

namespace Awaoa.Core.Entity
{
    public interface IAudit : IAudit<Guid>
    {
    }

    public interface IAudit<TPrimaryKeyOfUser> : ICreation<TPrimaryKeyOfUser>, IModification<TPrimaryKeyOfUser>, IDeletation<TPrimaryKeyOfUser>
    {
    }
}
