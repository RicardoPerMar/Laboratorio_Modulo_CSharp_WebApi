using Ejercicio1.Contracts;
using Ejercicio1.Models;
using Ejercicio1.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace Ejercicio1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly IActorRepository _actorRepository;
        public ActorController(IActorRepository actorRepository)
        {
            _actorRepository = actorRepository;
        }
        /*[HttpGet]
        public ActionResult<List<Actor>> GetAll()
        {
            return _actorRepository.GetActors();
        }*/

        [HttpGet]
        public ActionResult<Actor> GetById(int id)
        {
            return _actorRepository.GetActorById(id);
        }

        [HttpPatch]
        public ActionResult UpdateActor(Actor actor) 
        {
            try
            {
                _actorRepository.UpdateActor(actor);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPost]
        public ActionResult CreateActor(Actor actor)
        {
            try
            {
                _actorRepository.AddActor(actor);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public ActionResult DeleteActor(int id)
        {
            try
            {
                _actorRepository.DeleteActor(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
