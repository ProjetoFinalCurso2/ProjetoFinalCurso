using ProjetoFinal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal.Modelo
{
    public class Aluno : IPessoa
    {
        public string Idade { get; set; }
        public string RG { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public int CodigoCurso { get; set; }
    }
}
