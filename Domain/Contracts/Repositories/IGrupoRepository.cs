using System;
using System.Collections.Generic;
using UStart.Domain.Entities;

namespace UStart.Domain.Contracts.Repositories
{
    public interface IGrupoRepository
    {
        void Add(Grupo grupo);
        Grupo ConsultarPorId(Guid id);
        void Delete(Grupo grupo);
        IEnumerable<Grupo> Pesquisar(string pesquisa);
        void Update(Grupo grupo);
    }
}