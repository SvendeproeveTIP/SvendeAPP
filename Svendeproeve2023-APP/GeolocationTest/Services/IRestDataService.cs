using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeolocationTest.Services
{
    public interface IRestDataService
    {
        // CRUD FOR USERS
        Task<List<Users>> GetAllUsersAsync();
        Task AddUserAsync(Users user);
        Task DeleteUserAsync(long id);
        Task UpdateUserAsync(Users users);

        // CRUD FOR TRANSPORT

        Task<List<Vehicles>> GetAllVehicles();
        Task AddVehicleAsync(Vehicles vehicle);
        Task DeleteVehicleAsync(long id);
        Task UpdateVehicleAsync(Vehicles vehicles);

        // CRUD FOR ORDRES

        Task<List<Ordres>> GetAllOrdres();
        Task AddOrdreAsync(Ordres ordre);
        Task DeleteOrdreAsync(long id);
        Task UpdateOrdreAsync(Ordres ordre);
    }
}
