using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.DTO;
using DataAccess.Models;
using Common.Exceptions;
using Repositories.Contracts;

namespace Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {
        private readonly UsuariosContext _context;
        public UsuariosRepository(UsuariosContext context)
        {
             _context = context;
        }
        public void CreateUsuario(UsuarioDTO usuarioCreate)
        {
            _context.Add(new Usuario()
            {
                IdUsuario = usuarioCreate.IdUsuario,
                UserName = usuarioCreate.UserName,
                Nombre = usuarioCreate.Nombre,
                Telefono = usuarioCreate.Telefono,
                Email = usuarioCreate.Email
            });
            _context.SaveChanges();
        }
        public List<UsuarioDTO> GetAllUsuarios()
        {
            var response = new List<UsuarioDTO>();
            List<UsuarioDTO> listaEncontrada = _context.Usuarios.Select(x => new UsuarioDTO()
            {
                IdUsuario = x.IdUsuario,
                UserName = x.UserName,
                Nombre = x.Nombre,
                Telefono = x.Telefono,
                Email = x.Email,

            }).ToList();
            if (listaEncontrada != null)
            {
                response = listaEncontrada;
            }
            else
            {
                throw new UsuariosException($"No se encontraron usuarios en la base de datos.");
            }
            return response;
        }
        public UsuarioDTO GetUsuario(Guid idUsuario)
        {
            UsuarioDTO response = new UsuarioDTO();
            var usuarioEncontrado = _context.Usuarios.Where(x => x.IdUsuario == idUsuario).FirstOrDefault();
            if (usuarioEncontrado != null)
            {
                response = new UsuarioDTO()
                {
                    IdUsuario = usuarioEncontrado.IdUsuario,
                    UserName = usuarioEncontrado.UserName,
                    Nombre = usuarioEncontrado.Nombre,
                    Telefono = usuarioEncontrado.Telefono,
                    Email = usuarioEncontrado.Email,
                };
            }
            else
            {
                throw new UsuariosException($"No se ha encontrado el usuario con IdUsuario {idUsuario}");
            }

            return response;
        }
        public void UpdateUsuario(UsuarioDTO usuarioUpdate)
        {
            var usuarioEncontrado = _context.Usuarios.Where(x => x.IdUsuario == usuarioUpdate.IdUsuario).FirstOrDefault();

            if (usuarioEncontrado != null)
            {
                usuarioEncontrado.UserName = usuarioUpdate.UserName;
                usuarioEncontrado.Nombre = usuarioUpdate.Nombre;
                usuarioEncontrado.Telefono = usuarioUpdate.Telefono;
                usuarioEncontrado.Email = usuarioUpdate.Email;

                _context.Update(usuarioEncontrado);
                _context.SaveChanges();
            }
            else
            {
                throw new UsuariosException($"No se ha encontrado el usuario con IdUsuario {usuarioUpdate.IdUsuario}");
            }
        }
        public void DeleteUsuario(UsuarioDTO usuarioDelete)
        {
            var usuarioEncontrado = _context.Usuarios.Where(x => x.IdUsuario == usuarioDelete.IdUsuario).FirstOrDefault();

            if (usuarioEncontrado != null)
            {
                usuarioEncontrado.Activo = false;
                _context.Update(usuarioEncontrado);
            }
            else
            {
                throw new UsuariosException($"No se ha encontrado el usuario con IdUsuario {usuarioDelete.IdUsuario}");
            }
        }
    }
}
