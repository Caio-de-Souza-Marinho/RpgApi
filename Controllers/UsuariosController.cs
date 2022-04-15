using Microsoft.AspNetCore.Mvc;
using RpgApi.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
            else
            {
                return false;
            }
        }








        
    }
}