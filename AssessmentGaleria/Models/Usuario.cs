using System.ComponentModel.DataAnnotations;

namespace AssessmentGaleria.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo de Nome é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo de Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Campo de Senha é obrigatório")]
        public string Senha { get; set; }
    }
}
