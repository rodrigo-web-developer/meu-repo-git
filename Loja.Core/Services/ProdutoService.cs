using Loja.Core.Data;
using Loja.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace Loja.Core.Services
{
    public class ProdutoService
    {
        public bool Validar(Produto a, out List<ValidationResult> erros)
        {
            var contexto = new ValidationContext(a);
            erros = new List<ValidationResult>();
            var objetoValido = Validator.
                    TryValidateObject(
                        a, contexto, erros, true
                    );
            return objetoValido;
        }

        public List<Produto> Listar()
        {
            using var context = new LojaDbContext();
            return context.Produtos.ToList();
        }

        public bool Criar(Produto c)
        {
            if (!Validar(c, out var erros))
            {
                return false;
            }
            using var context = new LojaDbContext();
            context.Produtos.Add(c);
            context.SaveChanges();
            return true;
        }
    }
}
