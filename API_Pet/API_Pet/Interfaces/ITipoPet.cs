using API_Pet.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Pet.Interfaces
{
    interface ITipoPet
    {
        List<TipoPet> LerTodos();
        TipoPet BuscarPorId(int id);
        TipoPet Cadastrar(TipoPet a);
        TipoPet Alterar(int id,TipoPet a);
        void Excluir(int id);
    }
}
