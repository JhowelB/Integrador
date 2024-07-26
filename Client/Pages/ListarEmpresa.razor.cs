using Integrador.Shared.ViewModels;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace Integrador.Client.Pages
{
    public partial class ListarEmpresa
    {
        [Inject]
        public EmpresaViewModel ViewModel { get; set; }

        [Inject]
        public HttpClient Client { get; set; }

        protected override async Task OnInitializedAsync()
        {
            // Inicializar el modelo de empresa para evitar errores
            ViewModel.EmpresaToRegistry = new Integrador.Shared.Entities.Empresa();

            await GetData();
        }

        private async Task GetData()
        {
            var data = await Client.GetFromJsonAsync<List<Integrador.Shared.Entities.Empresa>>("api/Empresas");
            if (data != null)
            {
                ViewModel.Empresas = data;
            }
        }

        private async Task DeactivateEmpresa(int id)
        {
            var response = await Client.PutAsync($"api/Empresas/Deactivate/{id}", null);
            if (response.IsSuccessStatusCode)
            {
                await GetData();
            }
        }
    }
}
