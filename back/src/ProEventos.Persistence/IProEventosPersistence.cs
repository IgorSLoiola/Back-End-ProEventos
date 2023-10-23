// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using ProEventos.Domain;

// namespace ProEventos.Persistence.Contratos
// {
//     public interface IProEventosPersistence
//     {
//         //GERAL
//         void Add<T>(T entity) where T: class;
//         void Update<T>(T entity) where T: class;
//         void Delete<T>(T entity) where T: class;
//         void DeleteRange<T>(T[] entity) where T: class;
//         Task<bool> SaveChangesAsync();

//         //EVENTOS
//         Task<Evento> GetEventoByIdAsync(int EventoId, bool includePalestrantes);
//         Task<Evento[]> GetAllEventosByTemaAsync(bool includePalestrantes);
//         Task<Evento[]> GetAllEventosAsync(string tema, bool includePalestrantes);

//         //PALESTRANTES
//         Task<Palestrante> GetPalestranteByIdAsync(int PalestranteId, bool includeEventos);
//         Task<Palestrante[]> GetAllPalestrantesByNomeAsync(bool includeEventos);
//         Task<Palestrante[]> GetAllPalestrantesAsync(string Nome, bool includeEventos);
//     }
// }