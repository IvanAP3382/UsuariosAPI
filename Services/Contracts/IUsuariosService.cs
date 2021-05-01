using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IUsuariosService
    {
        ResponseDTO CreateUsuario(UsuarioDTO usuarioNuevo);
        ResponseDTO GetAllUsuarios();
        ResponseDTO GetUsuario(Guid idUsuario);
        ResponseDTO UpdateUsuario(UsuarioDTO usuarioActualizar);
        ResponseDTO DeleteUsuario(UsuarioDTO usuarioDelete);

    }
}
