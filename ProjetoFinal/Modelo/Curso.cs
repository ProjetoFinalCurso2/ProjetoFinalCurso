using ProjetoFinal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal.Modelo
{
    public class Curso : IEntidade
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Horario { get; set; }
        public List<Aluno> Alunos { get; set; }
        public int CodigoProfessor { get; set; }
    }
}
