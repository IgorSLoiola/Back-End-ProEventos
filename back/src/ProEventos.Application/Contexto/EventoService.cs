using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Application.Contratos;
using ProEventos.Persistence.Contratos;
using ProEventos.Domain;

namespace ProEventos.Application.Contexto
{
    public class EventoService : IEventosService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IEventoPersist _eventoPersist;
        public EventoService(IGeralPersist geralPersist, IEventoPersist eventoPersist)
        {
            _geralPersist = geralPersist;
            _eventoPersist = eventoPersist;
            
        }

        public async Task<Evento> AddEventos(Evento model){
            try{
                _geralPersist.Add<Evento>(model);
                if (await _geralPersist.SaveChangesAsync()){
                    return await _eventoPersist.GetEventoByIdAsync(model.Id, false);
                }
                return null;
            }catch (Exception ex){
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> UpdadeEventos(int EventoId, Evento model){
            try{
                var evento = await _eventoPersist.GetEventoByIdAsync(EventoId, false);
                if(evento == null){
                    return null;
                }

                model.Id = evento.Id;

                _geralPersist.Update(model);
                if(await _geralPersist.SaveChangesAsync()){
                    return await _eventoPersist.GetEventoByIdAsync(model.Id, false);
                }
                return null;
            }catch(Exception ex){
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEventos(int EventoId){
             try{
                var evento = await _eventoPersist.GetEventoByIdAsync(EventoId, false);
                if(evento == null){
                    throw new Exception("O evento para delete não foi encontrado.");
                }
                _geralPersist.Delete<Evento>(evento);
                return await _geralPersist.SaveChangesAsync();
            }catch(Exception ex){
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes){
            try{
                var eventos = await _eventoPersist.GetAllEventosAsync(includePalestrantes);
                if(eventos == null){
                    return null;
                }
                return eventos;
            }catch(Exception ex){
                throw new Exception(ex.Message);
            }
        }
        public async Task<Evento[]> GetAllEventosByTemaAsync(string Tema, bool includePalestrantes){
            try{
                var eventos = await _eventoPersist.GetAllEventosByTemaAsync(Tema, includePalestrantes);
                if(eventos == null){
                    return null;
                }
                return eventos;
            }catch(Exception ex){
                throw new Exception(ex.Message);
            }
        }
        public async Task<Evento> GetEventoByIdAsync(int EventoId, bool includePalestrantes){
            try{
                var eventos = await _eventoPersist.GetEventoByIdAsync(EventoId, includePalestrantes);
                if(eventos == null){
                    return null;
                }
                return eventos;
            }catch(Exception ex){
                throw new Exception(ex.Message);
            }
        }
    }
}