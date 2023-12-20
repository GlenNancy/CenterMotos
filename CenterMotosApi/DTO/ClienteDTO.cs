using CenterMotosApi.DTO.Builder;
using CenterMotosApi.Migrations;
using CenterMotosApi.Models;

namespace CenterMotosApi.DTO
{
    public class ClienteDTO
    {
        public int IdCliente { get; set; }
        public string NomeCliente { get; set; } 
        public ICollection<Comentario>? Comentarios { get; set; }
   
    }
}