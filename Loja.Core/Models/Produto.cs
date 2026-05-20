using System.ComponentModel.DataAnnotations;

namespace Loja.Core.Models
{
    public class Produto // produtos VERSÃO 2
    {
        public int Id { get; set; }
        [Required, StringLength(100)]
        public string Nome { get; set; }
        [Range(0, 1000)]
        public decimal Preco { get; set; }
        [Required]
        public Categoria Categoria { get; set; }
    }
}
