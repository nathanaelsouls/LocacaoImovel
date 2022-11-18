using APILocacaoImovel.Models;
using Microsoft.EntityFrameworkCore;

namespace APILocacaoImovel.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options)
            : base(options)
        {
            this.Database.Migrate();
        }

        public DbSet<ImovelModel> Imoveis { get; set; }
        public DbSet<LocacaoModel> Locacoes { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;initial catalog=locacao_imovel_novo;uid=root;pwd=123456", ServerVersion.Parse("8.0.31-mysql"));
        }        
    }
}
