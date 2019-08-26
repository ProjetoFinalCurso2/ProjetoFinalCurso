using ProjetoFinal.Interfaces;
using ProjetoFinal.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal.Servico
{
    public class ProfessorNegocio : INegocio<Professor>
    {
        private static List<Professor> professores;
        public ProfessorNegocio()
        {
            if (professores == null)
            {
                professores = new List<Professor>();
            }
        }
        public void Atualizar(Professor item, int codigo)
        {
            try
            {
                var professore = Selecionar(codigo);
                professore = item;
                professore.Codigo = codigo;
            }
            catch (Exception)
            {

                throw new Exception("Erro ao tentar atualizar professor");
            }
        }

        public void Deletar(Professor item)
        {
            try
            {
                professores.Remove(item);
            }
            catch (Exception)
            {

                throw new Exception("Erro ao tentar remover professor");
            }
        }

        public void Incluir(Professor item)
        {
            try
            {
                professores.Add(item);
            }
            catch (Exception)
            {

                throw new Exception("Erro ao tentar adicionar professor");
            }
        }

        public List<Professor> Listar()
        {
            try
            {
                return professores;
            }
            catch (Exception)
            {

                throw new Exception("Erro ao tentar listar professores");
            }
        }

        public Professor Selecionar(int id)
        {
            try
            {
                return professores.FirstOrDefault(r => r.Codigo == id);
            }
            catch (Exception)
            {

                throw new Exception("Erro ao tentar selecionar professor");
            }
        }
    }
}
