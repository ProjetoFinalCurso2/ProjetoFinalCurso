using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal.Interfaces
{
    interface IPessoa: IEntidade
    {
        string Idade { get; set; }
        string RG { get; set; }
        string Celular { get; set; }
        string Email { get; set; }
    }
}
