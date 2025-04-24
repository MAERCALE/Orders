using System.Reflection.Metadata.Ecma335;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Orders.FrondEnd.Repositories;
using Orders.Shared.Entites;

namespace Orders.FrondEnd.Pages.Countries
{
    public partial class CountryCreate
    {
        private Country country = new();
        private CountryForm? countryform;

        [Inject] private IRepository Repository { get; set; } = null!;
        [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;
        [Inject] private NavigationManager NavigationManager { get; set; } = null!;

        private async Task CreateAsync()
        {
            var responseHttp = await Repository.PostAsync("/api/countries/", country);
            if (responseHttp.Error) 
            { 
             var message = await responseHttp.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("Error",message, SweetAlertIcon.Error);
                return;
            }

            Return();
            var toast = SweetAlertService.Mixin(new SweetAlertOptions
            {
                Toast = true,
                Position = SweetAlertPosition.BottomEnd,
                ShowConfirmButton = true,
                Timer = 3000
            });
            await toast.FireAsync(icon: SweetAlertIcon.Success, message: "Registro creado con éxito.");

        }

        private void Return()
        {
            countryform!.FormPostedSuccessfully = true;
            NavigationManager.NavigateTo("/countries");
        }
    }
}
