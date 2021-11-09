using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using UStart.Domain.Contracts.Repositories;
using UStart.Domain.Entities;
using UStart.Infrastructure.Context;

namespace UStart.Infrastructure.Repositories
{

    public class ObraRepository : IObraRepository
    {
        private readonly UStartContext _context;

        public ObraRepository(UStartContext context)
        {
            _context = context;
        }

        public Obra ConsultarPorId(Guid id)
        {
            return _context
                .Obras
                .Include(g => g.Grupo)
                .FirstOrDefault(g => g.Id == id);
        }

        public IEnumerable<Obra> Pesquisar(string pesquisa)
        {
            pesquisa = pesquisa != null ? pesquisa.ToLower() : string.Empty;

            return _context
            .Obras            
            .Where(x => x.Descricao.ToLower().Contains(pesquisa)
                || x.Nome.ToLower().Contains(pesquisa))
            .ToList();
        }

        public void Add(Obra Obra)
        {
            _context.Obras.Add(Obra);
        }

        public void Update(Obra Obra)
        {
            _context.Obras.Update(Obra);
        }

        public void Delete(Obra Obra)
        {
            if (_context.Entry(Obra).State == EntityState.Detached)
            {
                _context.Obras.Attach(Obra);
            }
            _context.Obras.Remove(Obra);
        }
    }
}