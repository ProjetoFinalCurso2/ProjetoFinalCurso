using ProjetoFinal.Interfaces;
using ProjetoFinal.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal.Servico
{
    public class CursoNegocio : INegocio<Curso>
    {
        private static List<Curso> cursos;
        public CursoNegocio()
        {
            if (cursos == null)
            {
                cursos = new List<Curso>();
            }
        }
        public void Atualizar(Curso item, int codigo)
        {
            try
            {
                var professore = Selecionar(codigo);
                professore = item;
                professore.Codigo = codigo;
            }
            catch (Exception)
            {

                throw new Exception("Erro ao tentar atualizar curso");
            }
        }

        public void Deletar(Curso item)
        {
            try
            {
                cursos.Remove(item);
            }
            catch (Exception)
            {

                throw new Exception("Erro ao tentar remover curso");
            }
        }

        public void Incluir(Curso item)
        {
            try
            {
                cursos.Add(item);
            }
            catch (Exception)
            {

                throw new Exception("Erro ao tentar adicionar curso");
            }
        }

        public List<Curso> Listar()
        {
            try
            {
                return cursos;
            }
            catch (Exception)
            {

                throw new Exception("Erro ao tentar listar cursos");
            }
        }

        public Curso Selecionar(int id)
        {
            try
            {
                return cursos.FirstOrDefault(r => r.Codigo == id);
            }
            catch (Exception)
            {

                throw new Exception("Erro ao tentar selecionar curso");
            }
        }
    }
}
