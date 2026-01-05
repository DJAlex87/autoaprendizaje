using System;
using System.Collections.Generic;
using System.Linq;
using ClinicaApp.Domain.Model;

namespace ClinicaApp.Infraestructure.Persistence
{
    public static class InMemoryDatabase
    {
        public static List<Role> Roles { get; } = new();
        public static List<User> Users { get; } = new();
        public static List<Patient> Patients { get; } = new();

        public static void Seed()
        {
            if (Roles.Any()) return;

            Roles.AddRange(new[]
            {
                new Role { RoleId = 1, Name = "RecursosHumanos", Description = "Gestión de empleados" },
                new Role { RoleId = 2, Name = "Administrativo", Description = "Gestión de pacientes y facturación" },
                new Role { RoleId = 3, Name = "SoporteInformacion", Description = "Inventarios" },
                new Role { RoleId = 4, Name = "Enfermera", Description = "Visitas y signos vitales" },
                new Role { RoleId = 5, Name = "Medico", Description = "Historia clínica y órdenes" }
            });

            // Usuario admin RRHH por defecto
            Users.Add(new User
            {
                UserId = 1,
                Cedula = "1001",
                NombreCompleto = "Admin RRHH",
                Email = "admin.rrhh@clinica.com",
                Telefono = "1234567890",
                FechaNacimiento = new DateTime(1990, 1, 1),
                Direccion = "Calle 1",
                RoleId = 1,
                Username = "rrhh",
                PasswordHash = "Admin123!", // cumple reglas de contraseña
                Role = Roles.First(r => r.RoleId == 1)
            });

            Users.Add(new User
            {
                UserId = 2,
                Cedula = "2001",
                NombreCompleto = "Admin Pacientes",
                Email = "admin.pacientes@clinica.com",
                Telefono = "1234567890",
                FechaNacimiento = new DateTime(1990, 1, 1),
                Direccion = "Calle 2",
                RoleId = 2,
                Username = "admin",
                PasswordHash = "Admin123!",
                Role = Roles.First(r => r.RoleId == 2)
            });
        }
    }
}
