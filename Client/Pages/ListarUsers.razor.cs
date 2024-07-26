using Integrador.Shared.ViewModels;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace Integrador.Client.Pages
{
    public partial class ListarUsers
    {
        [Inject]
        public UserViewModel ViewModel { get; set; }

        [Inject]
        public HttpClient Client { get; set; }

        protected override async Task OnInitializedAsync()
        {
            // Inicializar el modelo de usuario para evitar errores
            ViewModel.UserToRegistry = new Integrador.Shared.Entities.Usuario();

            await GetData();
        }

        private async Task GetData()
        {
            var data = await Client.GetFromJsonAsync<List<Integrador.Shared.Entities.Usuario>>("api/Users");
            if (data != null)
            {
                ViewModel.Users = data;
            }
        }

        private async Task DeactivateUser(int id)
        {
            var response = await Client.PutAsync($"api/Users/Deactivate/{id}", null);
            if (response.IsSuccessStatusCode)
            {
                await GetData();
            }
        }
    }
}

