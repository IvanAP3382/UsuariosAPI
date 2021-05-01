using Common.DTO;
using Common.Exceptions;
using Repositories;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UsuariosService : IUsuariosService
    {
        private readonly IUsuariosRepository _repository;
        public UsuariosService(IUsuariosRepository repository)
        {
            _repository = repository;
        }
        public ResponseDTO CreateUsuario(UsuarioDTO usuarioNuevo)
        {
            ResponseDTO response = new ResponseDTO();
            try
            {
                _repository.CreateUsuario(usuarioNuevo);
            }
            catch (UsuariosException ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Ha ocurrido un error inesperado";
            }
            return response;
        }
        public ResponseDTO GetAllUsuarios()
        {
            ResponseDTO response = new ResponseDTO();
            try
            {
                response.Result = _repository.GetAllUsuarios();
            }
            catch (UsuariosException ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Ha ocurrido un error inesperado";
            }
            return response;
        }
        public ResponseDTO GetUsuario(Guid idUsuario)
        {
            ResponseDTO response = new ResponseDTO();
            try
            {
                response.Result = _repository.GetUsuario(idUsuario);
            }
            catch (UsuariosException ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Ha ocurrido un error inesperado";
            }
            return response;
        }
        public ResponseDTO UpdateUsuario(UsuarioDTO usuarioActualizar)
        {
            ResponseDTO response = new ResponseDTO();
            try
            {
                _repository.UpdateUsuario(usuarioActualizar);
            }
            catch (UsuariosException ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Ha ocurrido un error inesperado";
            }
            return response;
        }
        public ResponseDTO DeleteUsuario(UsuarioDTO usuarioDelete)
        {
            ResponseDTO response = new ResponseDTO();
            try
            {
                _repository.DeleteUsuario(usuarioDelete);
            }
            catch (UsuariosException ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Ha ocurrido un error inesperado";
            }
            return response;
        }


    }
}
