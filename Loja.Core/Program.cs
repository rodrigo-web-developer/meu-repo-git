using Loja.Core;
using Loja.Core.Models;
using Loja.Core.Services;
using Microsoft.Extensions.DependencyInjection;

var service = new CategoriaService();

while (true)
{
    Environment.SetEnvironmentVariable(
        "ConnectionStrings__DefaultConnection",
        "Server=localhost;Port=5432;User Id=postgres;Password=1234;Database=loja");

    Console.WriteLine("Digite a opcao:");
    var opcao = int.Parse(Console.ReadLine());

    if (opcao == 1)
    {
        var categorias = service.Listar();
        foreach (var item in categorias)
        {
            Console.WriteLine("{0}: {1}", item.Id, item.Nome);
        }
    }
    else if (opcao == 2)
    {
        var nome = Console.ReadLine();
        var categoria = new Categoria { Nome = nome };
        var sucesso = service.Criar(categoria, out _);
        if (!sucesso)
        {
            Console.WriteLine("Erro ao criar categoria");
        }
    }
}
