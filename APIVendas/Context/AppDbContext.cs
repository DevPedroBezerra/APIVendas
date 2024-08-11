using APIVendas.Models;
using Microsoft.EntityFrameworkCore;
using static APIVendas.Models.DepartamentosModel;
using static APIVendas.Models.ProdutosModel;
using static APIVendas.Models.VendasModel;
using static APIVendas.Models.VendedoresModel;

namespace APIVendas.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<DepartamentosModel> Departamentos { get; set; }
        public DbSet<VendedoresModel> Vendedores { get; set; }
        public DbSet<VendasModel>  Vendas { get; set; }
        public DbSet<ProdutosModel> Produtos { get; set; }
    }
}