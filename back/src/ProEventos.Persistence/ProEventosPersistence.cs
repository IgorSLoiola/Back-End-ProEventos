// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using ProEventos.Domain;

// namespace ProEventos.Persistence
// {
//     public class ProEventosPersistence : IProEventosPersistence
//     {
//         private readonly ProEventosContext _context;
//         public ProEventosPersistence(ProEventosContext context)
//         {
//             _context = context;
            
//         }

//         public void Add<T>(T entity) where T : class{
//             _context.Add(entity);
//         }
//         public void Update<T>(T entity) where T : class{
//             _context.Update(entity);
//         }
//         public void Delete<T>(T entity) where T : class{
//             _context.Remove(entity);
//         }
//         public void DeleteRange<T>(T[] entityArray) where T : class{
//             _context.RemoveRange(entityArray);
//         }
//         public async Task<bool> SaveChargesAsync(){
//             return (await _context.SaveChangesAsync()) > 0;
//         }

//         //EVENTOS

//         public async task<Eventos[]> GetAllEventosByTemaAsync(string tema, bool includeEventos){
//             IQueryable<Evento> query = _context.Evento
//                                                .Include(e => e.Lotes)
//                                                .Include(e => e.RedesSociais);
//             if(includePalestrantes){
//                 query = query.Include(e => e.PalestrantesEventos)
//                              .ThenInclude(pe => pe.Palestrante )
//             }

//             query = query.OrderBy(e => e.Id).where(e.Tema.ToLower().Contains(GetAllEventosByTemaAsync.ToLower));

//             return await query.ToArrayAsync();
//         }
//         public async task<Eventos[]> GetAllEventosAsync(includeEventos = false);{
//             IQueryable<Evento> query = _context.Evento
//                                                .Include(e => e.Lotes)
//                                                .Include(e => e.RedesSociais);
//             if(includePalestrantes){
//                 query = query.Include(e => e.PalestrantesEventos).ThenInclude(pe => pe.Palestrante )
//             }

//             query = query.OrderBy(e => e.Id);

//             return await query.ToArrayAsync();
//         }

//         //PALESTRANTES

//         public async task<Palestrante[]> GetAllPalestrantesByNomeAsync(string Nome, bool includeEventos){
//             IQueryable<Palestrante> query = _context.Palestrantes.Include(p => p.RedesSociais);

//             if(includeEventos){
//                 query = query.Include(p => p.PalestrantesEventos).ThenInclude(pe => pe.Evento )
//             }

//             query = query.OrderBy(p => p.Id).Where(p => p.Nome.ToLower().Contains(nome.ToLower));

//             return await query.ToArrayAsync();
//         }
//         public async task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos  = false);{
//             IQueryable<Palestrante> query = _context.Palestrantes.Include(p => p.RedesSociais);

//             if(includeEventos){
//                 query = query.Include(p => p.PalestrantesEventos).ThenInclude(pe => pe.Evento )
//             }

//             query = query.OrderBy(p => p.Id);

//             return await query.ToArrayAsync();
//         }


//         // ID

//         public async task<Eventos[]> GetEventoByIdAsync(int EventoId, bool includeEventos){
//             IQueryable<Evento> query = _context.Evento
//                                                .Include(e => e.Lotes)
//                                                .Include(e => e.RedesSociais);
//             if(includePalestrantes){
//                 query = query.Include(e => e.PalestrantesEventos)
//                              .ThenInclude(pe => pe.Palestrante )
//             }

//             query = query.OrderBy(e => e.Id).where(e => e.Id == EventoId);

//             return await query.FirstOrDefaultAsync();
//         }

//         public async task<Palestrante[]> GetPalestranteByIdAsync(int PalestranteId, bool includeEventos){
//             IQueryable<Evento> query = _context.Evento
//                                                .Include(e => e.Lotes)
//                                                .Include(e => e.RedesSociais);
//             if(includePalestrantes){
//                 query = query.Include(p => p.Eventos)
//             }

//             query = query.OrderBy(p => p.Id).where(p => p.Id == PalestranteId);

//             return await query.FirstOrDefaultAsync();
//         }
//     }
// }