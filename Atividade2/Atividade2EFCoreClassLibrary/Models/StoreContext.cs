using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Atividade2EFCoreClassLibrary.Models
{
    public class StoreContext : DbContext
    {
        public DbSet<Conta> Contas { get; set; }
        public DbSet<ContaCorrente> ContasCorrente { get; set; }
        public DbSet<ContaPoupanca> ContasPoupanca { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Agencia> Agencias { get; set; }
        public DbSet<Banco> Bancos { get; set; }
        public DbSet<Solicitacao> Solicitacoes { get; set; }
        public DbSet<ClienteSolicitacao> ClienteSolicitacoes { get; set; }

        private static IConfigurationRoot Configuration;

        public StoreContext()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection = (Configuration.GetConnectionString("StoreDB"));
            optionsBuilder.UseSqlServer(connection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClienteSolicitacao>()
                .HasKey(cs => new { cs.ClienteId, cs.SolicitacaoId });

            modelBuilder.Entity<ClienteSolicitacao>()
                .HasOne(c => c.Cliente)
                .WithMany(cs => cs.ClienteSolicitacoes)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
