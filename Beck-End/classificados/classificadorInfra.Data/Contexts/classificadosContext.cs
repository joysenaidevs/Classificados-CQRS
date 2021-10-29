using classificados.Dominio;
using classificados.Dominio.Entidades;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classificados.Infra.Data.Contexts
{
    public class classificadosContext : DbContext
    {
        // criar metodo construtor sem atributo
        // passamos o argumento de options que será definido posteriormente na minha Startup da API
        public classificadosContext(DbContextOptions<classificadosContext> options) : base(options)
        {


        }

        // Declarar quais sao as tabelas que vamos criar, com dbset
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        //public DbSet<Comentario> Comentarios { get; set; }

        // modelamos como as tabelas devem ficar
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // mapeando as tabelas
            // region : tratar de uma regiao de codigos , caso extenso

            //ignoramos que alib de notificações do flunt seja gerada no banco automaticamente
            modelBuilder.Ignore<Notification>();

            #region Mapeamento da tabela usuarios
            // mudamos o nome da tabela se necessario
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");

            // determinar chaves, não precisa determinar  como primary key ja que está nomeado como ID
            modelBuilder.Entity<Usuario>().Property(x => x.Id);

            // vamos tratar atributos :  Nome / Email / Senha

            // --------------------------------- Nome ---------------------------------------------
            modelBuilder.Entity<Usuario>().Property(x => x.Nome).HasMaxLength(40);
            modelBuilder.Entity<Usuario>().Property(x => x.Nome).HasColumnType("varchar (40)");
            modelBuilder.Entity<Usuario>().Property(x => x.Nome).IsRequired();


            // --------------------------------- Email ---------------------------------------------
            modelBuilder.Entity<Usuario>().Property(x => x.Email).HasMaxLength(60);
            modelBuilder.Entity<Usuario>().Property(x => x.Email).HasColumnType("varchar (60)");
            modelBuilder.Entity<Usuario>().Property(x => x.Email);
            modelBuilder.Entity<Usuario>(entity => entity.HasIndex(u => u.Email).IsUnique());


            // --------------------------------- Senha ---------------------------------------------
            modelBuilder.Entity<Usuario>().Property(x => x.Senha).HasMaxLength(200);
            modelBuilder.Entity<Usuario>().Property(x => x.Senha).HasColumnType("varchar (200)");
            modelBuilder.Entity<Usuario>().Property(x => x.Senha).IsRequired();


            // --------------------------------- DataCriação ---------------------------------------------
            modelBuilder.Entity<Usuario>().Property(x => x.Date).HasColumnType("DateTime");
            #endregion

            #region Mapeamento da tabela Produtos
            //mudamos o nome da tabela se necessario
            modelBuilder.Entity<Produto>().ToTable("Produto");

            // determinar chaves, não precisa determinar  como primary key ja que está nomeado como ID
            modelBuilder.Entity<Produto>().Property(x => x.Id);

            // vamos tratar atributos : Nome / Imagem / Descricao / Status / Preço

            // --------------------------------- Nome ---------------------------------------------
            modelBuilder.Entity<Produto>().Property(x => x.Nome).HasMaxLength(100);
            modelBuilder.Entity<Produto>().Property(x => x.Nome).HasColumnType("varchar (100)");
            modelBuilder.Entity<Produto>().Property(x => x.Nome).IsRequired();

            // --------------------------------- Imagem ---------------------------------------------
            modelBuilder.Entity<Produto>().Property(x => x.Imagem).HasMaxLength(100);
            modelBuilder.Entity<Produto>().Property(x => x.Imagem).HasColumnType("varchar (100)");
            modelBuilder.Entity<Produto>().Property(x => x.Imagem).IsRequired();

            // --------------------------------- Descricao ---------------------------------------------
            modelBuilder.Entity<Produto>().Property(x => x.Descricao).HasMaxLength(100);
            modelBuilder.Entity<Produto>().Property(x => x.Descricao).HasColumnType("varchar (100)");
            modelBuilder.Entity<Produto>().Property(x => x.Descricao).IsRequired();

            // --------------------------------- Status ---------------------------------------------
            modelBuilder.Entity<Produto>().Property(x => x.Status).HasMaxLength(100);
            modelBuilder.Entity<Produto>().Property(x => x.Status).HasColumnType("varchar (100)");
            modelBuilder.Entity<Produto>().Property(x => x.Status).IsRequired();

            // --------------------------------- Preco ---------------------------------------------
            modelBuilder.Entity<Produto>().Property(x => x.Preco).HasColumnType("float");

           
            #endregion

            // pegando todas as ações desse metodo na superclasse
            base.OnModelCreating(modelBuilder);

        }
    }
}
