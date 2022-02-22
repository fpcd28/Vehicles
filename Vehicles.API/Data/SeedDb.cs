using System;
using System.Linq;
using System.Threading.Tasks;
using Vehicles.API.Data.Entities;
using Vehicles.API.Helpers;
using Vehicles.Common.Enums;

namespace Vehicles.API.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext context , IUserHelper userHelper) 
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckVehiclesTypeAsync();
            await CheckBrandsAsync();
            await CheckDocumentTypesAsync();
            await CheckProceduresAsync();
            await CheckRolesAsync();
            await CheckUserAsync("1010", "Freddy ","Carhuachin Diaz","fpcd28@gmail.com","996152516","Smp",UserType.Admin);
            await CheckUserAsync("2020", "Juan", "Salazar", "fpcd@hotmail.com", "996152516", "Smp", UserType.User);
            await CheckUserAsync("3030", "Percy", "Bedoya", "fpcd@gmail.com", "996152516", "Smp", UserType.User);
         }

        private async Task CheckUserAsync(string document, string firsName, string lastName, string email, string phoneNumber, string address, UserType userType)
        {
            User user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                user = new User
                {
                    Address = address,
                    Document = document,
                    DocumentType = _context.DocumentTypes.FirstOrDefault(x => x.Description == "Cédula"),
                    Email = email,
                    FirtName = firsName,
                    LastName = lastName,
                    PhoneNumber = phoneNumber,
                    UserName = email,
                    UserType = userType
                };
                await _userHelper.AddUserAsync(user,"123456");
                await _userHelper.AddUserToRoleAsync(user,userType.ToString());
            }
        }

        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
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
