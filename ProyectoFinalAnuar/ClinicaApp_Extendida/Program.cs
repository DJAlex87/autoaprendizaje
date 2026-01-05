using System;
using System.Windows.Forms;
using ClinicaApp.Infraestructure.GUI;
using ClinicaApp.Infraestructure.Persistence;

namespace ClinicaApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Usar SQL, no InMemory
            ServiceLocator.UseInMemory = false;

            ApplicationConfiguration.Initialize();

            System.Windows.Forms.Application.Run(new LoginForm());
        }
    }
}
