using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using UStart.Domain.Contracts.Repositories;
using UStart.Domain.Entities;
using UStart.Infrastructure.Context;

namespace UStart.Infrastructure.Repositories
{
    public class GrupoRepository : IGrupoRepository
    {
        private readonly UStartContext _context;

        public GrupoRepository(UStartContext context)
        {
            _context = context;
        }

        public Grupo ConsultarPorId(Guid id)
        {
            return _context.Grupos.FirstOrDefault(g => g.Id == id);
        }

        public IEnumerable<Grupo> Pesquisar(string pesquisa)
        {
            pesquisa = pesquisa != null ? pesquisa.ToLower() : string.Empty;

            return _context
            .Grupos
            .Where(x => x.Descricao.ToLower().Contains(pesquisa))
            .ToList();
        }

        public void Add(Grupo grupo)
        {
            _context.Grupos.Add(grupo);            
        }

        public void Update(Grupo grupo)
        {
            _context.Grupos.Update(grupo);
        }

        public void Delete(Grupo grupo)
        {
            if (_context.Entry(grupo).State == EntityState.Detached)
            {
                _context.Grupos.Attach(grupo);
            }
            _context.Grupos.Remove(grupo);
        }
    }
}