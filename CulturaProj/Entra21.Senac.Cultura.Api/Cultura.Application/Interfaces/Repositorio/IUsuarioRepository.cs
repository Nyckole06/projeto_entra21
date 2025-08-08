using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cultura.Application.Dtos.Output;
using Cultura.Domain.Entities;

namespace Cultura.Application.Interfaces.Repositorio
{
    public interface IUsuarioRepository
    {
        Task CreateUsuario(Usuario usuario); 

        Task<Usuario> GetUsuarioByEmail(string email, string senha);
    }
}
