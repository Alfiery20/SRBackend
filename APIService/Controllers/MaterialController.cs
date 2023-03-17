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
    public class MaterialController : ControllerBase
    {
        [HttpPost("listarMaterial")]
        public IActionResult ListarMaterial([FromBody] ListarMaterialRequest listarMaterialRequest)
        {
            try
            {
                ClnMaterial clnMaterial = new ClnMaterial();
                var request = clnMaterial.ListarMaterial(listarMaterialRequest);
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

        [HttpPost("agregarMaterial")]
        public IActionResult AddMaterial([FromBody] IUDMaterialRequest iUDMaterial)
        {
            try
            {
                ClnMaterial clnMaterial = new ClnMaterial();
                var request = clnMaterial.IudMaterial(iUDMaterial, "I");
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

        [HttpPut("editarMaterial")]
        public IActionResult EditMaterial([FromBody] IUDMaterialRequest iUDMaterial)
        {
            try
            {
                ClnMaterial clnMaterial = new ClnMaterial();
                var request = clnMaterial.IudMaterial(iUDMaterial, "U");
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

        [HttpDelete("eliminarMaterial")]
        public IActionResult DelMaterial([FromBody] IUDMaterialRequest iUDMaterial)
        {
            try
            {
                ClnMaterial clnMaterial = new ClnMaterial();
                var request = clnMaterial.IudMaterial(iUDMaterial, "D");
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

        [HttpGet("obtenerMaterial/{id}")]
        public IActionResult ObtenerMaterial(int id)
        {
            try
            {
                ClnMaterial clnMaterial = new ClnMaterial();
                var request = clnMaterial.ObtenerMaterial(id);
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
