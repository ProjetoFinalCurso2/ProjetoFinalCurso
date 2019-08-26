using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal.Interfaces
{
    interface INegocio<T>
    {
        void Incluir(T item);
        void Atualizar(T item, int codigo);
        void Deletar(T item);
        T Selecionar(int id);
        List<T> Listar();
    }
}
