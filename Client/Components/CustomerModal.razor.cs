using EN.Shared;
using Microsoft.AspNetCore.Components;

namespace EN.Client.Components;

    public partial class CustomerModal
    {

        [Parameter] public Customer ModalCustomer { get; set; } =default!;

        [Parameter]
        public EventCallback<Customer> OnModalSave { get; set; }

        [Parameter]
        public EventCallback OnModalClose { get; set; }

        private async Task ModalClose()
        {
            await OnModalClose.InvokeAsync();
        }

        private async Task ModalSave()
        {
            await OnModalSave.InvokeAsync(ModalCustomer);
        }


        protected override void OnInitialized()
        {
            base.OnInitialized();
        }
    }
