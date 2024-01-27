using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UbicuaFinal.Data
{
    public class UbicuaDbContext : DbContext
    {
        private const string _connection = "Server=DESKTOP-N752V6F\\SQLEXPRESS;Initial Catalog=DatosVacunas;User ID=sa;Password=1q2w3e4r;TrustServerCertificate=True;";
            public DbSet<Dato> Datos { get; set; } // Reemplaza TuEntidad y TuTabla con nombres apropiados

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(_connection);
            }
    }
}
