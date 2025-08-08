using Cultura.Application.Dtos.Input;
using Cultura.Application.Dtos.Output;
using Cultura.Application.Interfaces.Repositorio;
using Cultura.Application.Interfaces.Service;
using Cultura.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cultura.Application.Services
{
    public class UsuarioService : IUsuarioService
    {

        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task CreateUsuario(UsuarioCreateDto usuarioDto)
        {
            // Map UsuarioCreateDto to Usuario entity
            var usuario = new Usuario
            {
                Nome = usuarioDto.Nome,
                Email = usuarioDto.Email,
                Senha = usuarioDto.Senha,
                Telefone = usuarioDto.Telefone,
                DataNascimento = usuarioDto.DataNascimento,
                Endereco = new Endereco
                {
                    Cep = usuarioDto.Endereco.Cep,
                    Estado = usuarioDto.Endereco.Estado,
                    Cidade = usuarioDto.Endereco.Cidade,
                    Bairro = usuarioDto.Endereco.Bairro,
                    Numero = usuarioDto.Endereco.Numero,
                    Rua = usuarioDto.Endereco.Rua
                }
            };

            await _usuarioRepository.CreateUsuario(usuario);
        }
        public async Task<UsuarioDadosLoginDto> GetUsuarioByEmail(string email, string senha)
        {
            var usuario = await _usuarioRepository.GetUsuarioByEmail(email, senha);
            if (usuario == null)
                return null;
            return new UsuarioDadosLoginDto
            {
                Nome = usuario.Nome,
                Email = usuario.Email,
                Telefone = usuario.Telefone,
                DataNascimento = usuario.DataNascimento,
                Endereco = new EnderecoDadosLoginDto
                {
                    Cep = usuario.Endereco.Cep,
                    Estado = usuario.Endereco.Estado,
                    Cidade = usuario.Endereco.Cidade,
                    Bairro = usuario.Endereco.Bairro,
                    Numero = usuario.Endereco.Numero,
                    Rua = usuario.Endereco.Rua
                }
            };
        }
    }
        
}