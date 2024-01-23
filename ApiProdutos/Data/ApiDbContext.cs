using ApiProduto.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiProdutos.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options)
        : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }
    }
}
    