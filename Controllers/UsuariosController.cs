using Microsoft.AspNetCore.Mvc;
using RpgApi.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RpgApi.Models;
using RpgApi.Utils;

namespace RpgApi.Controllers
{
    
    [ApiController]
    [Route("[Controller]")]

    public class UsuariosController : ControllerBase
    {
        
        private readonly DataContext _context;

        public UsuariosController(DataContext context)
        {
            _context = context;
        }

        // Método para verificar se um usuário já existe no banco de dados
        private async Task<bool> UsuarioExistente(string username)
        {
            if(await _context.Usuarios.AnyAsync(x => x.Username.ToLower() == username.ToLower()))
            {
                return true;
            }    
        return false;
            
        }

        // Método para registrar um usuário, caso o username não exista no banco de dados
        [HttpPost("Registrar")]
        public async Task<IActionResult> RegistrarUsuario(Usuario user)
        {
            try
            {
                if(await UsuarioExistente(user.Username))
                    throw new System.Exception("Nome de usuário já existe");

                    Criptografia.CriarPasswordHash(user.PasswordString, out byte[] hash, out byte[] salt);
                    user.PasswordString = string.Empty;
                    user.PasswordHash = hash;
                    user.PasswordSalt = salt;
                    await _context.Usuarios.AddAsync(user);
                    await _context.SaveChangesAsync();

                    return Ok(user.Id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }









    }
}