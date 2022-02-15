using System.Linq;
using System.Threading.Tasks;
using Vehicles.API.Data.Entities;

namespace Vehicles.API.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckVehiclesTypeAsync();
            await CheckBrandsAsync();
            await CheckDocumentTypesAsync();
            await CheckProceduresAsync();
        }

        private async Task CheckProceduresAsync()
        {
            if (!_context.Procedures.Any())
            {
                _context.Procedures.Add(new Procedure { Price = 1000, Description = "Alineamiento" });
                _context.Procedures.Add(new Procedure { Price = 1000, Description = "Lubricacion de Suspencion delantera" });
                _context.Procedures.Add(new Procedure { Price = 1000, Description = "Lubricacion de Suspencion atras" });
                _context.Procedures.Add(new Procedure { Price = 1000, Description = "Frenos Delantero" });
                _context.Procedures.Add(new Procedure { Price = 1000, Description = "Liquido de Frenos Delantero" });
                _context.Procedures.Add(new Procedure { Price = 1000, Description = "Liquido de Frenos trasero" });
                _context.Procedures.Add(new Procedure { Price = 1000, Description = "Calibracion de valvula" });
                _context.Procedures.Add(new Procedure { Price = 1000, Description = "Alineacion de carburador" });
                _context.Procedures.Add(new Procedure { Price = 1000, Description = "Aceite Motor" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckDocumentTypesAsync()
        {
            if (!_context.DocumentTypes.Any())
            {
                _context.DocumentTypes.Add(new DocumentType { Description = "Cedula" });
                _context.DocumentTypes.Add(new DocumentType { Description = "DNI" });
                _context.DocumentTypes.Add(new DocumentType { Description = "NIT" });
                _context.DocumentTypes.Add(new DocumentType { Description = "Pasaporte" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckBrandsAsync()
        {
            if (!_context.Brands.Any())
            {
                _context.Brands.Add(new Brand { Description = "Ducati" });
                _context.Brands.Add(new Brand { Description = "Harley Davidson" });
                _context.Brands.Add(new Brand { Description = "Ktm" });
                _context.Brands.Add(new Brand { Description = "BMV" });
                _context.Brands.Add(new Brand { Description = "Triumps" });
                _context.Brands.Add(new Brand { Description = "Victoria" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckVehiclesTypeAsync()
        {
            if (!_context.VehicleTypes.Any())
            {
                _context.VehicleTypes.Add(new VehicleType { Description = "Carro" });
                _context.VehicleTypes.Add(new VehicleType { Description = "Moto" });
                await _context.SaveChangesAsync();
            }
        }





    }
}
