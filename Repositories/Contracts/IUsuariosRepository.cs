using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IUsuariosRepository
    {
        void CreateUsuario(UsuarioDTO usuarioCreate);
        List<UsuarioDTO> GetAllUsuarios();
        UsuarioDTO GetUsuario(Guid idUsuario);
        void UpdateUsuario(UsuarioDTO usuarioUpdate);
        void DeleteUsuario(UsuarioDTO usuarioDelete);
    }
}
