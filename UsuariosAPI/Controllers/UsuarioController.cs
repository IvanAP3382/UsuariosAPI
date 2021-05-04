using Common.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsuariosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuariosService _usuarioService;
        public UsuarioController(IUsuariosService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        [HttpPost("CreateUsuario")]
        public object CreateUsuario([FromBody] UsuarioDTO usuarioNuevo)
        {
            return _usuarioService.CreateUsuario(usuarioNuevo);
        }
        [HttpGet("GetAllUsuarios")]
        public object GetAllUsuarios()
        {
            return _usuarioService.GetAllUsuarios();
        }
        [HttpPost("GetUsuario")]
        public object GetUsuario([FromBody] Guid idUsuarioBuscar)
        {
            return _usuarioService.GetUsuario(idUsuarioBuscar);
        }

        [HttpPost("UpdateUsuario")]
        public object UpdateUsuario([FromBody] UsuarioDTO usuarioActualizar)
        {
            return _usuarioService.UpdateUsuario(usuarioActualizar);
        }
        [HttpPost("DeleteUsuario")]
        public object DeleteUsuario([FromBody] UsuarioDTO usuarioDelete)
        {
            return _usuarioService.DeleteUsuario(usuarioDelete);
        }
    }
}
