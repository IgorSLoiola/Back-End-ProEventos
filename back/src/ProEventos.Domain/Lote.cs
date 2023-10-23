using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Domain
{
    public class Lote
    {
        public int Id {get; set;}
        public string Nome {get; set;}
        public decimal Preco {get; set;}
        public string DataInicio {get; set;}
        public string DataFim {get; set;}
        // public DateTime? DataInicio {get; set;}
        // public DateTime? DataFim {get; set;}
        public int Qauntidade {get; set;}
        public int EventoId {get; set;}
        public Evento Eventos {get; set;}
    }
}