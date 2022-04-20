using System;

namespace Server
{
    public abstract class BaseEntity
    {
        public virtual Guid Id { get; set; }
        public virtual string Email { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime? AtualizadoEm { get; set; }
        public bool Deletada { get; set; }
    }
}
