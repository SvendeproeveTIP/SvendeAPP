using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeolocationTest.Services
{
    public interface IRestDataService
    {
        Task<List<Users>> GetAllUsersAsync();
        Task AddUserAsync(Users user);
        Task DeleteUserAsync(int id);
        Task UpdateUserAsync(Users users);
    }
}
