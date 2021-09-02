namespace BlazorShop.Web.Client.Pages.Account
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Models.Identity;

    public partial class Login
    {
        private readonly LoginRequestModel model = new LoginRequestModel();

        public bool ShowErrors { get; set; }

        public IEnumerable<string> Errors { get; set; }

        private async Task SubmitAsync()
        {
            var result = await this.AuthService.Login(this.model);

            if (result.Succeeded)
            {
                this.ShowErrors = false;
                this.ToastService.ShowSuccess("تم تسجيل الدخول بنجاح");
                this.NavigationManager.NavigateTo("/Categories/categorylist",forceLoad:true);
                
            }
            else
            {
                this.Errors = result.Errors;
                this.ShowErrors = true;
            }
        }
    }
}
