using Integrador.Shared.ViewModels;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace Integrador.Client.Pages
{
    public partial class ListarCategoria
    {
        [Inject]
        public CategoriaViewModel ViewModel { get; set; }

        [Inject]
        public HttpClient Client { get; set; }

        protected override async Task OnInitializedAsync()
        {
            // Inicializar el modelo de categoría para evitar errores
            ViewModel.CategoriaToRegistry = new Integrador.Shared.Entities.Categoria();

            await GetData();
        }

        private async Task GetData()
        {
            var data = await Client.GetFromJsonAsync<List<Integrador.Shared.Entities.Categoria>>("api/Categorias");
            if (data != null)
            {
                ViewModel.Categorias = data;
            }
        }

        private async Task DeactivateCategoria(int id)
        {
            var response = await Client.PutAsync($"api/Categorias/Deactivate/{id}", null);
            if (response.IsSuccessStatusCode)
            {
                await GetData();
            }
        }
    }
}
