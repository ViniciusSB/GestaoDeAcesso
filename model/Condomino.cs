using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeAcesso.model
{
    class Condomino
    {
        public int id;
        public String nome;
        public String email;
        public String sexo;
        public String dataNascimento;
        public String rg;
        public String cpf;
        public String tipoUsuario;
        public Endereco endereco;
        public List<Automovel> automovel;
    }
}
