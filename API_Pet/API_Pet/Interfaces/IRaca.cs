using API_Pet.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Pet.Interfaces
{
    interface IRaca
    {
        List<Raca> LerTodos();
        Raca BuscarPorId(int id);
        Raca Cadastrar(Raca a, int id);
        Raca Alterar(int id, Raca a);
        void Excluir(int id);
    }
}
