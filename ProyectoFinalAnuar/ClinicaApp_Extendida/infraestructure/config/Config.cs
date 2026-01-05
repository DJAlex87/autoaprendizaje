namespace ClinicaApp.Infraestructure.Config
{
    public static class Config
    {
        // Ajusta esta cadena a tu instancia de SQL Server
        public static string ConnectionString =>
            @"Server=DESKTOP-G3UI9S3\SQLEXPRESS;Database=ClinicaDB;Trusted_Connection=True;TrustServerCertificate=True;";
    }
}
