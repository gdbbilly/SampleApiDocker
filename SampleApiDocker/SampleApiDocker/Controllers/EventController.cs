using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SampleApiDocker.Business;
using SampleApiDocker.Entities;
using SampleApiDocker.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApiDocker.Controllers
{
   public class EventController : Controller
    {
        protected IConfiguration _configuration;
        protected IMapper _mapper;

        public EventController(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
        }


        /// <summary>
        /// Get Event
        /// </summary>
        /// <returns>Object of Event</returns>
        [HttpGet("/Event/Get")]
        public async Task<IActionResult> Get(string eventId)
        {
            try
            {
                var facade = Facade.Instance.Factory<EventEntitie>();
                var @event = facade.Get(x=>x.Id.Equals(new Guid(eventId)));
                if (@event == null)
                    return NotFound("Not Find Event");

                var model = _mapper.Map<EventModel>(@event);

                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error on Find Event" });
            }
        }

        /// <summary>
        /// Get Event
        /// </summary>
        /// <returns>Object of Event</returns>
        [HttpGet("/Event/GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var facade = Facade.Instance.Factory<EventEntitie>();
                var events = facade.GetAll();

                var model = _mapper.Map<List<EventModel>>(events);

                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error on Find Event" });
            }
        }

        /// <summary>
        /// Create Event
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("/Event/Create")]
        public async Task<IActionResult> Create([FromBody] EventModel model)
        {
            try
            {
                if (model == null)
                {
                    throw new Exception("Problema ao receber parametros");
                }

                var facade = Facade.Instance.Factory<EventEntitie>();
                facade.Insert(_mapper.Map<EventEntitie>(model));

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error on Create Event" });
            }
        }

        /// <summary>
        /// Create Event
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpDelete("/Event/Delete")]
        public async Task<IActionResult> Delete(string eventId)
        {
            try
            {
                var facade = Facade.Instance.Factory<EventEntitie>();
                var @event = facade.Get(x => x.Id.Equals(new Guid(eventId)));
                if (@event == null)
                    return NotFound("Not Find Event");

                facade.Delete(@event);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error on Create Event" });
            }
        }
    }
}
