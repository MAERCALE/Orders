using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components;
using Orders.Shared.Entites;

namespace Orders.FrondEnd.Pages.Categories
{
    public partial class CategoryForm
    {
        private EditContext editContext = null!;

        [Parameter, EditorRequired] public Category Category { get; set; } = null!;
        [Parameter, EditorRequired] public EventCallback OnValidSubmit { get; set; }
        [Parameter, EditorRequired] public EventCallback ReturAction { get; set; }
        [Inject] public SweetAlertService SweetAlertService { get; set; } = null!;
        public bool FormPostedSuccessfully { get; set; } = false;

        protected override void OnInitialized()
        {
            editContext = new(Category);
        }

        private async Task OnBeforeInternalNavigation(LocationChangingContext context)
        {
            var formWasEdited = editContext.IsModified();
            if (!formWasEdited || FormPostedSuccessfully)
            {
                return;
            }
            var result = await SweetAlertService.FireAsync(new SweetAlertOptions
            {
                Title = "Confirmación",
                Text = "¿Deseas abandonar la página y perder los cambios?",
                Icon = SweetAlertIcon.Question,
                ShowCancelButton = true
            });
            var Confirm = !string.IsNullOrEmpty(result.Value);
            if (Confirm)
            {
                return;
            }
            context.PreventNavigation();
        }
    }
}