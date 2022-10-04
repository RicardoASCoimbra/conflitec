using Conflitec.Domain.Core.Models;
using Conflitec.Domain.Enuns;

namespace Conflitec.Domain.Models
{
    public class Usuarios : Entity
    {
        //Texto
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public string Email { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Escolaridade { get; private set; }
        public bool Excluido { get; private set; }
        public Usuarios()
        { }

        public Usuarios(
            Guid id,
            string nome,
            string sobrenome,
            string email,
            DateTime dataNascimento,
            string escolaridade)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            DataNascimento = dataNascimento;
            Escolaridade = escolaridade;
            Excluido = false;
        }

        public void SetDados(
            string nome,
            string sobrenome,
            string email,
            DateTime dataNascimento,
            string escolaridade)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            DataNascimento = dataNascimento;
            Escolaridade = escolaridade;
            Excluido = false;
        }

        public void SetExcluido(bool flag)
        {
            Excluido = flag;
        }
    }
}

