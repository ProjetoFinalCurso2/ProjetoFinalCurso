using ProjetoFinal.Interfaces;
using ProjetoFinal.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal.Servico
{
    public class AlunoNegocio : INegocio<Aluno>
    {
        private static List<Aluno> alunos;
        public AlunoNegocio()
        {
            if (alunos == null)
            {
                alunos = new List<Aluno>();
            }            
        }
        public void Atualizar(Aluno item, int codigo)
        {
            try
            {
                var aluno = Selecionar(codigo);
                aluno = item;
                aluno.Codigo = codigo;
            }
            catch (Exception)
            {

                throw new Exception("Erro ao tentar atualizar aluno");
            }
        }

        public void Deletar(Aluno item)
        {
            try
            {
                alunos.Remove(item);
            }
            catch (Exception)
            {

                throw new Exception("Erro ao tentar deletar aluno");
            }
        }

        public void Incluir(Aluno item)
        {
            try
            {
                alunos.Add(item);
            }
            catch (Exception)
            {

                throw new Exception("Erro ao tentar adicionar aluno");
            }
        }

        public List<Aluno> Listar()
        {
            try
            {
                return alunos;
            }
            catch (Exception)
            {

                throw new Exception("Erro ao tentar listar alunos");
            }
        }

        public Aluno Selecionar(int id)
        {
            try
            {
                return alunos.FirstOrDefault(r => r.Codigo == id);
            }
            catch (Exception)
            {

                throw new Exception("Erro ao tentar selecionar aluno");
            }
        }
    }
}
