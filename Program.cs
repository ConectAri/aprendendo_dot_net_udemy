using Microsoft.AspNetCore.Mvc;

 
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        app.MapGet("/", () => "Hello World Ariane testando 3 !");
        app.MapPost("/", () => new { Name = "Ariane Linda", Age = 35 });
        app.MapGet("/AddHeader", (HttpResponse response) =>
        {
            response.Headers.Add("Teste", "Ariane Linda");
            return new { Name = "Ariane Linda", Age = 35 };
        });

        app.MapPost("/saveproduct", (Product product) =>
        {
            return product.Code + " - " + product.Name;
        });

        //Por meio de parâmetros via Query
        //api.app.com/users?datastart={date}&dateend={date}
        app.MapGet("/getproduct", ([FromQuery] string dateStart, [FromQuery] string dateEnd) =>{
            return dateStart + " - " + dateEnd;
        });

        //Por meio de rota
        //api.app.com/user/{code}
        app.MapGet("/getproduct/{code}", ([FromRoute] string code) => {
            return code;

        });

        app.MapGet("/getproductbyheader", (HttpRequest request) => {
            return request.Headers["product-code"].ToString();

        });

        app.Run();


        //criei uma classe simulando como se ela fosse um banco de dados.

        /* Este código define uma classe chamada "ProductRepository" que representa um repositório de produtos.
         A classe possui uma propriedade chamada "Products" que é uma lista de objetos "Product".
         A classe também possui um método chamado "Add" que recebe um objeto "Product" como argumento e adiciona o objeto à lista "Products".
        O método "Add" verifica se a lista "Products" é nula e, se for, cria uma nova instância de uma lista "Product" antes de adicionar
        o objeto "Product" recebido como argumento à lista "Products".

        Em resumo, a classe "ProductRepository" permite adicionar objetos "Product" a uma lista de produtos e é usada como um repositório
        para armazenar e gerenciar informações sobre os produtos.

        */

        public static class ProductRepository{

            public static List<Product> Products { get; set; }

            public static void Add(Product product){
                if(Products == null)
                Products = new List<Product>();

                Products.Add(product);
            }

            public static Product GetBy(string code){
                return Products.First(p => p.Code == code);
            }
        }

   /* 
   Este método recebe uma string chamada "code" como argumento e retorna o primeiro objeto "Product" encontrado na lista 
   "Products" que possui um código (propriedade "Code") igual à string "code" fornecida como argumento.

    O método usa o método de extensão "First" da classe "Enumerable" para encontrar o primeiro objeto "Product" na lista "Products"
    que atenda à condição especificada na expressão lambda: "p => p.Code == code". Essa expressão verifica se a propriedade
     "Code" do objeto "Product" é igual à string "code" fornecida como argumento.

    Em resumo, o método "GetBy" é usado para buscar um objeto "Product" na lista "Products" com base no código do produto e retornar
    o objeto correspondente. Se nenhum objeto for encontrado na lista com o código especificado, o método lançará uma exceção
    "InvalidOperationException".
      
  */





public class Product{
    public string Code { get; set; }
    public string Name { get; set; }
}
