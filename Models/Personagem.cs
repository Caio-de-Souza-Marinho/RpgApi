using RpgApi.Models.Enuns;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace RpgApi.Models
{
    public class Personagem
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int PontosVida { get; set; }
        public int Forca { get; set; }
        public int Defesa { get; set; }
        public int Inteligencia { get; set; }
        public ClasseEnum Classe { get; set; }
        public byte[] FotoPersonagem { get; set; }
        
        public Usuario Usuario { get; set; }
        
        public Arma Arma { get; set; }
        public List<PersonagemHabilidade> PersonagemHabilidades { get; set; }
    }
}