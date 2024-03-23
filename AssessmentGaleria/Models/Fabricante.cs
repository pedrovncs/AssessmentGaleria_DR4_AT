using System.ComponentModel.DataAnnotations;

namespace AssessmentGaleria.Models
{
    public class Fabricante
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo de Nome é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo de Nacionalidade é obrigatório")]
        public string Nacionalidade { get; set; }
        [Required(ErrorMessage = "Campo descrição é obrigatório")]
        public string Descricao { get; set; }
        public List<Carro> Carros { get; set; } =  new List<Carro>();

    }
}
