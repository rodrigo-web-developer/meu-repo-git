namespace Loja.Core.Dtos
{
    public class CreateProdutoDto
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int CategoriaId { get; set; }
    }
}
