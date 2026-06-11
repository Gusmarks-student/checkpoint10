using System.ComponentModel.DataAnnotations;

namespace IMCApp.Models
{
    public class EnderecoViewModel
    {
        [Required(ErrorMessage = "O CEP é obrigatório.")]
        public string CEP { get; set; } = string.Empty;

        [Required(ErrorMessage = "O logradouro é obrigatório.")]
        public string Logradouro { get; set; } = string.Empty;

        [Required(ErrorMessage = "O bairro é obrigatório.")]
        public string Bairro { get; set; } = string.Empty;

        [Required(ErrorMessage = "A localidade (cidade) é obrigatória.")]
        public string Localidade { get; set; } = string.Empty;

        [Required(ErrorMessage = "A UF é obrigatória.")]
        public string UF { get; set; } = string.Empty;

        [Required(ErrorMessage = "O número é obrigatório.")]
        public string Numero { get; set; } = string.Empty;

        public string Complemento { get; set; } = string.Empty;
    }
}
