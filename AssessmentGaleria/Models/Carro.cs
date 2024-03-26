using System.ComponentModel.DataAnnotations;

namespace AssessmentGaleria.Models
{
    public class Carro
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo de Modelo é obrigatório")]
        public string Modelo { get; set; }
        [Required(ErrorMessage = "Campo de Descrição é obrigatório")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Campo de Informações é obrigatório")]
        public string Info { get; set; }
        [Required(ErrorMessage = "Campo de Ano é obrigatório")]
        public string Ano { get; set; }
        [Required(ErrorMessage = "Campo de Imagem é obrigatório")]
        public String Imagem { get; set; }
    }
}
