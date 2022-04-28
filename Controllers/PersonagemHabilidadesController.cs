using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using RpgApi.Models;
using Microsoft.EntityFrameworkCore;
using RpgApi.Data;
using System.Linq;
using System;


namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class PersonagemHabilidadesController : ControllerBase
    {
        private readonly DataContext _context;

        public PersonagemHabilidadesController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddPersonagemHabilidadeAsync(PersonagemHabilidade novoPersonagemHabilidade)
        {
            try
            {
                Personagem personagem = await _context.Personagens
                    .Include(p => p.Arma)
                    .Include(p => p.PersonagemHabilidades).ThenInclude(ps => ps.Habilidade)
                    .FirstOrDefaultAsync(p => p.Id == novoPersonagemHabilidade.PersonagemId);

                if(personagem == null)
                    throw new System.Exception("Personagem não encontrado para o ID informado.");

                Habilidade habilidade = await _context.Habilidades
                                    .FirstOrDefaultAsync(h => h.Id == novoPersonagemHabilidade.HabilidadeId);

                if(habilidade == null)
                    throw new System.Exception("Habilidade não encontrada.");

                PersonagemHabilidade ph = new PersonagemHabilidade();
                ph.Personagem = personagem;
                ph.Habilidade = habilidade;
                await _context.PersonagemHabilidades.AddAsync(ph);
                int linhaAfetadas = await _context.SaveChangesAsync();

                return Ok(linhaAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Desafio 5
        [HttpGet("{id}")]
                public async Task<IActionResult> GetByPersonagemId(int id)
                {
                    try
                    {
                        PersonagemHabilidade personaId = await _context.PersonagemHabilidades
                            .Include(h => h.Personagem.PersonagemHabilidades)
                            .FirstOrDefaultAsync(per => per.PersonagemId == id);

                        return Ok(personaId);
                    }
                    catch (System.Exception ex)
                    {
                        return BadRequest (ex.Message);
                    }
                }
        
        //Desafio 6
        [HttpGet("GetHabilidades")]

        public async Task<IActionResult> GetHabilidades()
        {
            try
            {
                List<Habilidade> lista = await _context.Habilidades
                    .ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest (ex.Message);
            }
        }








    }
}