﻿
using Conflitec.Infra.Data.Mapping.Maps;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Conflitec.Infra.Data.Context
{
    public class ConflitecDB : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Prod"}.json").Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //        EXEMPLOS 
            //        Aqui inserimos os MAPEAMENTOS DA PASTA MAPPING

            //Usuario
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            //modelBuilder.ApplyConfiguration(new AnexoGaleriaFotosPrincipalMap());





            //-------------------------------------------------------------------------------------------------------------------------------------

            modelBuilder
                .Model
                .GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where
                (
                    p => p.ClrType == typeof(string) ||
                         p.ClrType == typeof(DateTime) || p.ClrType == typeof(DateTime?) ||
                         p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)
                )
                .ToList()
                .ForEach(x =>
                {
                    var Type = string.Empty;

                    if (x.ClrType == typeof(string))
                    {
                        if (!x.GetMaxLength().HasValue)
                            modelBuilder.Entity(x.DeclaringType.ClrType).Property(x.Name).HasMaxLength(50);
                    }
                    else
                    {
                        if (x.ClrType == typeof(DateTime) || x.ClrType == typeof(DateTime?))
                            Type = "DATETIME";
                        else
                            Type = "DECIMAL(18,6)";

                        modelBuilder.Entity(x.DeclaringType.ClrType).Property(x.Name).HasColumnType(Type);
                    }
                });
        }
    }
}