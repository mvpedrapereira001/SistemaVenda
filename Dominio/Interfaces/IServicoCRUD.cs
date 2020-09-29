using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Interfaces
{
    public interface IServicoCRUD<TEntidade>
        where TEntidade: class
    {
        IEnumerable<TEntidade> Lisagem();
        void Cadastrar(TEntidade categoria);
        TEntidade CarregarRegistro(int id);
        void Excluir(int id);

    }
}
