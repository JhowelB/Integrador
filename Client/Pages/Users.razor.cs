using Integrador.Shared.Entities;
using Integrador.Shared.ViewModels;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace Integrador.Client.Pages
{
    public partial class Users
    {
        [Inject]
        public UserViewModel ViewModel { get; set; }

        [Inject]
        public HttpClient Client { get; set; }

        protected override async Task OnInitializedAsync()
        {
            ViewModel.UserToRegistry = new Usuario();
            await GetData();
        }

        public async Task Save()
        {
            var response = await Client.PostAsJsonAsync("api/Users/Add", ViewModel.UserToRegistry);
            if (response.IsSuccessStatusCode)
            {
                await GetData();
                Navigation.NavigateTo("/Listarusuarios"); // Opcional: redirige a otra página después de guardar
            }
            else
            {
                // Manejar error
            }
        }

        private async Task GetData()
        {
            var data = await Client.GetFromJsonAsync<List<Usuario>>("api/Users");
            if (data != null)
            {
                ViewModel.Users = data;
            }
        }
    }
}
