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
    public class EventoPersist : IEventoPersist
    {
        private readonly ProEventosContext _context;
        public EventoPersist(ProEventosContext context)
        {
            _context = context;
            // _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking();
            
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false){
            IQueryable<Evento> query = _context.Eventos.Include(e => e.Lotes).Include(e => e.RedeSociais);
            if(includePalestrantes){
                query = query.Include(e => e.PalestranteEventos).ThenInclude(pe => pe.Palestrantes);
            };

            query = query.AsNoTracking().OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }
        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false){
            IQueryable<Evento> query = _context.Eventos.Include(e => e.Lotes).Include(e => e.RedeSociais);

            if (includePalestrantes){
                query = query.Include(e => e.PalestranteEventos).ThenInclude(pe => pe.Palestrantes);
            }

            query = query.AsNoTracking().OrderBy(e => e.Id).Where(e => e.Tema.ToLower().Contains(tema.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Evento> GetEventoByIdAsync(int EventoId, bool includePalestrantes = false){
            IQueryable<Evento> query = _context.Eventos
                                               .Include(e => e.Lotes)
                                               .Include(e => e.RedeSociais);
            if(includePalestrantes){
                query = query.Include(e => e.PalestranteEventos).ThenInclude(pe => pe.Palestrantes);
            }

            query = query.AsNoTracking().OrderBy(e => e.Id).Where(e => e.Id == EventoId);

            return await query.FirstOrDefaultAsync();
        }
    }
}