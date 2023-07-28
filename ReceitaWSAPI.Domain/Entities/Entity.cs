using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceitaWSAPI.Domain.Entities
{
    public abstract class Entity<T> : AbstractValidator<T> where T : Entity<T>
    {
        public int Id { get; set; }
        public bool Ativo { get; set; }
        public string? IdUsuarioCriacao { get; set; }
        public DateTime? DataHoraCriacao { get; set; }
    }
}

