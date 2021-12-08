using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeAcesso.model
{
    class Visitante
    {
        public int id;
        public String nome;
        public String sexo;
        public String dataNascimento;
        public String documentoIdentificacao;
        public String tipoUsuario;
        public Endereco endereco;
        public List<Automovel> automovel;
    }
}
