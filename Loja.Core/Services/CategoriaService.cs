using Loja.Core.Data;
using Loja.Core.Dtos;
using Loja.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace Loja.Core.Services
{
    public class CategoriaService
    {
        public CategoriaService()
        {

        }
        public bool Validar(Categoria a, out List<ValidationResult> erros)
        {
            var contexto = new ValidationContext(a);
            erros = new List<ValidationResult>();
            var objetoValido = Validator.
                    TryValidateObject(
                        a, contexto, erros, true
                    );
            return objetoValido;
        }

        public List<Categoria> Listar()
        {
            using var context = new LojaDbContext();
            return context.Categorias.ToList();
        }

        public bool Criar(Categoria c, out List<ValidationResult> erros)
        {
            if (!Validar(c, out erros))
            {
                return false;
            }
            using var context = new LojaDbContext();
            context.Categorias.Add(c);
            context.SaveChanges();
            return true;
        }
        public bool Editar(UpdateCategoriaDto c, out List<ValidationResult> erros)
        {
            using var context = new LojaDbContext();
            var registroExistente = context.Categorias.FirstOrDefault(
                x => x.Id == c.Id
                );

            if (registroExistente == null)
            {
                Console.WriteLine("teste");
                erros = new List<ValidationResult>();
                erros.Add(new ValidationResult("Categoria não encontrada"));
                return false;
            }

            registroExistente.Nome = c.Nome;

            if (!Validar(registroExistente, out erros))
            {
                return false;
            }
            context.SaveChanges();
            return true;
        }
    }
}
