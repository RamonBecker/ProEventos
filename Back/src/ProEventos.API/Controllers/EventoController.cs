﻿using System.Net.Mime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
      
       public IEnumerable<Evento> evento = new Evento[]{

               new Evento  {  EventoId = 1, Tema = "Angular 11 e .NET 5", Local = "Belo Horizonte", Lote = "1º Lote", QtdPessoas = 250, DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"), ImagemURL = "foto.pn"}
            };

        public EventoController()
        {
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return evento;
        }

        [HttpGet("{id}")]
        public IEnumerable<Evento> Get(int id)
        {
            return evento.Where( evento => evento.EventoId == id);
        }
}
}


