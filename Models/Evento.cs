using System.ComponentModel.DataAnnotations;

namespace Exercicios_ASP_NET_CoreMVC.Models
{
    public class Evento
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "O nome do evento é obrigatório.")]
        [StringLength(80, MinimumLength = 5, ErrorMessage = "O nome do evento deve ter entre 5 e 80 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "A descrição do evento é obrigatória.")]
        [MinLength(10, ErrorMessage = "A descrição do evento deve ter no mínimo 10 caracteres.")]
        public string Descricao { get; set; } = string.Empty;

        [Required(ErrorMessage = "O local do evento é obrigatório.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O local do evento deve ter entre 3 e 100 caracteres.")]
        public string Local { get; set; } = string.Empty;

        public DateTime DataEvento { get; set; }

        [Range(1, 1000, ErrorMessage = "A quantidade de vagas deve ser entre 1 e 1000.")]
        public int QuantidadeVagas { get; set; }

        public decimal ValorIngresso { get; set; }
    }
}