using System;

namespace Awaoa.Core.Entity
{
    public interface ICreation: ICreation<Guid>
    {

    }

    public interface ICreation<TPrimaryKeyOfUser>
    {
        DateTime CreatedAt { get; set; }

        TPrimaryKeyOfUser CreatedBy { get; set; }
    }
}
