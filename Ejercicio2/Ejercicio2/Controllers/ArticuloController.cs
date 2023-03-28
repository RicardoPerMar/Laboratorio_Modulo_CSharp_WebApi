using Ejercicio2.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Ejercicio2.Models;
using System;

namespace Ejercicio2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloController : ControllerBase
    {
        private readonly IArticuloRepository _articuloRepository;
        public ArticuloController(IArticuloRepository articuloRepository)
        {
            _articuloRepository = articuloRepository;
        }

        [HttpGet]
        public ActionResult<List<Articulo>> GetArticulos()
        {
            return _articuloRepository.GetArticulos();
        }

        [HttpPost]
        public ActionResult AddArticulo(Articulo articulo)
        {
            try
            {
                _articuloRepository.AddArticulo(articulo);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /*[HttpPatch]
        public ActionResult IncArticulo(int id, int cant)
        {
            try
            {
                _articuloRepository.IncArticulo(id, cant);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            
        }*/

        [HttpPatch]
        public ActionResult DecArticulo(int id, int cant)
        {
            try
            {
                _articuloRepository.DecArticulo(id, cant);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }
    }
}
