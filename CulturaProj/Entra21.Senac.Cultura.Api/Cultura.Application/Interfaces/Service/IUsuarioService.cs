using Cultura.Application.Dtos.Input;
using Cultura.Application.Dtos.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cultura.Application.Interfaces.Service
{
    public interface IUsuarioService
    {
        Task CreateUsuario(UsuarioCreateDto usuarioCreateDto);
        Task<UsuarioDadosLoginDto> GetUsuarioByEmail(string email, string senha);
    }
}
