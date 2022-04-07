using System.Collections.Generic;
using RpgApi.Models;
using RpgApi.Models.Enuns;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class PersonagemExercicioController : ControllerBase
    {
        private static List<Personagem> personagens = new List<Personagem>(){
            new Personagem() { Id = 1, Nome = "Frodo", PontosVida = 100, Forca = 17, Defesa = 23, Inteligencia = 33, Classe = ClasseEnum.Cavaleiro},
            new Personagem() { Id = 2, Nome = "Sam", PontosVida = 100, Forca = 15, Defesa = 25, Inteligencia = 30, Classe = ClasseEnum.Cavaleiro},
            new Personagem() { Id = 3, Nome = "Galadriel", PontosVida = 100, Forca = 18, Defesa = 21, Inteligencia = 35, Classe = ClasseEnum.Clerigo},
            new Personagem() { Id = 4, Nome = "Gandalf", PontosVida = 100, Forca = 18, Defesa = 18, Inteligencia = 37, Classe = ClasseEnum.Mago},
            new Personagem() { Id = 5, Nome = "Hobbit", PontosVida = 100, Forca = 20, Defesa = 17, Inteligencia = 31, Classe = ClasseEnum.Cavaleiro},
            new Personagem() { Id = 6, Nome = "Celeborn", PontosVida = 100, Forca = 21, Defesa = 13, Inteligencia = 34, Classe = ClasseEnum.Clerigo},
            new Personagem() { Id = 7, Nome = "Ragadast", PontosVida = 100, Forca = 25, Defesa = 11, Inteligencia = 35, Classe = ClasseEnum.Mago}
        };
    
    
        [HttpGet("GetByClasse/{classeId}")]
        public IActionResult GetByClasse(int classeId)
        {
            //List<Personagem> listaFinal = personagens.FindAll(x => x.Classe == (ClasseEnum)classeId); 
            return Ok(personagens.FindAll(x => x.Classe == (ClasseEnum)classeId));

        }

        [HttpGet("GetByNome/{nomeDigitado}")]
        public IActionResult GetByNome(string nomeDigitado)
        {
            List<Personagem> todosPersonagens = personagens.FindAll(x => x.Nome == nomeDigitado);
            if(todosPersonagens.Count == 0)            
                return NotFound ("O nome digitado não foi encontrado");            
            else
                return Ok(todosPersonagens);            
        }

        [HttpPost("PostValidacao")]
        public IActionResult PostValidacao(Personagem novPersonagem)
        {
            if(novPersonagem.Defesa < 10 || novPersonagem.Inteligencia > 30)
                return BadRequest("A defesa não pode ter um valor menor que 10.\n A inteligência não pode ter um valor maior que 30");

            else
                personagens.Add(novPersonagem);
                return Ok(novPersonagem);
        }

        [HttpPost("PostValidacaoMago")]
        public IActionResult PostValidacaoMago(Personagem nvPersonagem)
        {
            if(nvPersonagem.Classe == ClasseEnum.Mago && nvPersonagem.Inteligencia < 35)
                return BadRequest("A inteligência não pode ser menor que 35 para Magos.");    
            else
                personagens.Add(nvPersonagem);
                return Ok(nvPersonagem);
                
        }

        [HttpGet("GetClerigoMago")]
        public IActionResult GetSemCavaleiro()
        {
            List<Personagem> listaBusca = personagens.FindAll(p => p.Classe != ClasseEnum.Cavaleiro)
            .OrderByDescending(p => p.Inteligencia)
            .ToList();
            
            return Ok(listaBusca);
        }

        [HttpGet("GetEstatisticas")]
        public IActionResult GetEstatisticas()
        {
            string fraseEstatisticas = string.Format("Existem {0} personagens na lista \n O somatório da Inteligência dos personagens é de {1}", personagens.Count, personagens.Sum(x => x.Inteligencia));
            return Ok(fraseEstatisticas);
        }
    }
}