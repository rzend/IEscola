using System;

namespace IEscola.Domain.Entities
{
    public abstract class EntityBase
    {
        public Guid Id { get; set; }
        

        public DateTime DataCadastro { get; private set; }
        public bool Ativo { get; private set; }

        public DateTime DataUltimaAlteracao { get; set; }
        public string UsuarioCadastro { get; set; }
        public string UsuarioUltimaAlteracao { get; set; }

        protected EntityBase()
        {
            DataCadastro = DateTime.Now;
            DataUltimaAlteracao = DateTime.Now;
            Ativo = true;
        }

        public void Inativar()
        {
            Ativo = false;
        }

        public void Ativar()
        {
            Ativo = true;
        }
    }
}
