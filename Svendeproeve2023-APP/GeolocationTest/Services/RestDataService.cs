using GeolocationTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeolocationTest.Services
{
    public class RestDataService : IRestDataService
    {
        HttpClient _httpClient;
        string _baseAddress;
        string _url;
        JsonSerializerOptions _jsonSerializerOptions;

        public List<Users> Users { get; private set; }

        public RestDataService()
        {
            _httpClient = new HttpClient();
            _baseAddress = DeviceInfo.Platform == DevicePlatform.Android ? "http://192.168.0.2:5279" : "https://localhost:7105";
            _url = $"{_baseAddress}/api";

            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }




        public async Task AddUserAsync(Users user)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("---> No Internet Access....");
                return;
            }

            try
            {
                string jsonUser = JsonSerializer.Serialize<Users>(user, _jsonSerializerOptions);
                StringContent content = new StringContent(jsonUser, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync($"{_url}/User", content);

                if(response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("Successfully created a user");
                }
                else
                {
                    Debug.WriteLine("---> Non Http 2xx response");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Whoops exception: {ex.Message}");
            }

            return;
        }

        public async Task DeleteUserAsync(int id)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("---> No Internet Access....");
                return;
            }

            try
            {
                HttpResponseMessage response = await _httpClient.DeleteAsync($"{_url}/User/{id}");

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("Successfully deleted user");
                }
                else
                {
                    Debug.WriteLine("---> Non Http 2xx response");
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine($"Whoops exception: {ex.Message}");
            }

            return;
        }

        public async Task<List<Users>> GetAllUsersAsync()
        {
            Users = new List<Users>();

            if(Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("---> No Internet Access....");
                return Users;
            }

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{_url}/User");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    Users = JsonSerializer.Deserialize<List<Users>>(content, _jsonSerializerOptions);
                }
                else
                {
                    Debug.WriteLine("---> Non Http 2xx response");
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine($"Whoops exception: {ex.Message}");
            }

            return Users;
        }

        public async Task UpdateUserAsync(Users user)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("---> No Internet Access....");
                return;
            }

            try
            {
                string jsonUser = JsonSerializer.Serialize<Users>(user, _jsonSerializerOptions);
                StringContent content = new StringContent(jsonUser, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PutAsync($"{_url}/User/{user.Id}", content);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("Successfully updated user");
                }
                else
                {
                    Debug.WriteLine("---> Non Http 2xx response");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Whoops exception: {ex.Message}");
            }

            return;
        }
    }
}
