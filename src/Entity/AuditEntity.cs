using System;

namespace Awaoa.Core.Entity
{
    public abstract class AuditEntity<TPrimarykey> : AuditEntity<TPrimarykey, Guid>
    {
    }

    public abstract class AuditEntity<TPrimarykey, TPrimaryKeyOfUser>
                        : IEntity<TPrimarykey>, IAudit<TPrimaryKeyOfUser>
    {
        public virtual TPrimarykey Id { get; set; }

        public virtual DateTime CreatedAt  { get; set; }

        public virtual TPrimaryKeyOfUser CreatedBy  { get; set; }

        public virtual DateTime ModifiedAt  { get; set; }

        public virtual TPrimaryKeyOfUser ModifiedBy  { get; set; }

        public virtual DateTime? DeletedAt  { get; set; }

        public virtual TPrimaryKeyOfUser DeletedBy  { get; set; }

        public virtual bool IsDeleted  { get; set; }
    }
}
