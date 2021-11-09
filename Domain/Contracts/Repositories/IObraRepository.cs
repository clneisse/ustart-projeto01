using System;
using System.Collections.Generic;
using UStart.Domain.Entities;

namespace UStart.Domain.Contracts.Repositories
{
    public interface IObraRepository
    {
        void Add(Obra Obra);
        Obra ConsultarPorId(Guid id);
        void Delete(Obra Obra);
        IEnumerable<Obra> Pesquisar(string pesquisa);
        void Update(Obra Obra);
    }

}