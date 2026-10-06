using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    //CONFIGURACAO DB
    //1- Instalar bibliotecas
    //2- Criar classe de dados
    //3- Criar heranca com a biblioteca
    //4- Indicar as classes de modelo que vao virar tabelas no db
    //5- Sobreescrever o metodo de configuracao, com o banco de dados

    //Passando por Referencia pro Atributo do DBContext (EF)
    public class AppDataContext : DbContext
    {
        public DbSet<Product> Produtos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Ecommerce.db");
        }
    }
}