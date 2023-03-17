﻿using CEN.Request;
using CLN;
using CEN;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace APIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        [HttpPost("listarCategorias")]
        public IActionResult ListarCategorias([FromBody] ListarCategoriaRequest listarCategoriaRequest)
        {
            try
            {
                ClnCategoria clnCategoria = new ClnCategoria();
                var request = clnCategoria.ListarCategoria(listarCategoriaRequest);
                return Ok(request);
            }
            catch (Exception ex)
            {
                ClnControlError obj = new ClnControlError();
                var error = new CenControlError
                {
                    Tipo = "R",
                    Descripcion = ex.Message
                };
                obj.InsertControlError(error);
                return BadRequest(error);
            }
        }

        [HttpPost("agregarCategoria")]
        public IActionResult AddCategoria([FromBody] IUDCategoriaRequest iUDCategoria)
        {
            try
            {
                ClnCategoria clnCategoria = new ClnCategoria();
                var request = clnCategoria.IudCategoria(iUDCategoria, "I");
                return Ok(request);
            }
            catch (Exception ex)
            {
                ClnControlError obj = new ClnControlError();
                var error = new CenControlError
                {
                    Tipo = "C",
                    Descripcion = ex.Message
                };
                obj.InsertControlError(error);
                return BadRequest(error);
            }
        }

        [HttpPut("editarCategoria")]
        public IActionResult EditCategoria([FromBody] IUDCategoriaRequest iUDCategoria)
        {
            try
            {
                ClnCategoria clnCategoria = new ClnCategoria();
                var request = clnCategoria.IudCategoria(iUDCategoria, "U");
                return Ok(request);
            }
            catch (Exception ex)
            {
                ClnControlError obj = new ClnControlError();
                var error = new CenControlError
                {
                    Tipo = "C",
                    Descripcion = ex.Message
                };
                obj.InsertControlError(error);
                return BadRequest(error);
            }
        }

        [HttpDelete("eliminarCategoria")]
        public IActionResult DelCategoria([FromBody] IUDCategoriaRequest iUDCategoria)
        {
            try
            {
                ClnCategoria clnCategoria = new ClnCategoria();
                var request = clnCategoria.IudCategoria(iUDCategoria, "D");
                return Ok(request);
            }
            catch (Exception ex)
            {
                ClnControlError obj = new ClnControlError();
                var error = new CenControlError
                {
                    Tipo = "C",
                    Descripcion = ex.Message
                };
                obj.InsertControlError(error);
                return BadRequest(error);
            }
        }

        [HttpGet("obtenerCategoria/{id}")]
        public IActionResult ObtenerCategoria(int id)
        {
            try
            {
                ClnCategoria clnCategoria = new ClnCategoria();
                var request = clnCategoria.ObtenerCategoria(id);
                return Ok(request);
            }
            catch (Exception ex)
            {
                ClnControlError obj = new ClnControlError();
                var error = new CenControlError
                {
                    Tipo = "R",
                    Descripcion = ex.Message
                };
                obj.InsertControlError(error);
                return BadRequest(error);
            }
        }
    }
}
