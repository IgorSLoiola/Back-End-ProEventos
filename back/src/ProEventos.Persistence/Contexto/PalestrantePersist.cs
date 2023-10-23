using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Domain;
using ProEventos.Persistence;
using ProEventos.Persistence.Contratos;
using Microsoft.EntityFrameworkCore;

namespace ProEventos.Persistence.Contexto
{
    public class PalestrantePersist : IPalestrantePersist
    {
        private readonly ProEventosContext _context;
        public PalestrantePersist(ProEventosContext context)
        {
            _context = context;
            
        }
        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string Nome, bool includeEventos){
            IQueryable<Palestrante> query = _context.Palestrantes.Include(p => p.RedeSociais);

            if(includeEventos){
                query = query.Include(p => p.PalestranteEventos).ThenInclude(pe => pe.Eventos );
            }

            query = query.OrderBy(p => p.Id).Where(p => p.Nome.ToLower().Contains(Nome.ToLower()));

            return await query.ToArrayAsync();
        }
        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos  = false){
            IQueryable<Palestrante> query = _context.Palestrantes.Include(p => p.RedeSociais);

            if(includeEventos){
                query = query.Include(p => p.PalestranteEventos).ThenInclude(pe => pe.Eventos );
            }

            query = query.OrderBy(p => p.Id);

            return await query.ToArrayAsync();
        }
         
        // ID

        public async Task<Palestrante> GetPalestranteByIdAsync(int PalestranteId, bool includeEventos){
            IQueryable<Palestrante> query = _context.Palestrantes.Include(p => p.RedeSociais);
            if(includeEventos){
                query = query.Include(p => p.PalestranteEventos).ThenInclude(pe => pe.Eventos);
            }

            query = query.OrderBy(p => p.Id).Where(p => p.Id == PalestranteId);

            return await query.FirstOrDefaultAsync();
        }
    }
}