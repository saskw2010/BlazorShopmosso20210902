namespace BlazorShop.Web.Client.Pages.Categories
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using BlazorInputFile;
    using Models.Categories;
    using Models.Products;
    

    public partial class Addcat
    {
        //string status;/*saeed*/
        
        private readonly CategoriesRequestModel model = new CategoriesRequestModel();

        private IEnumerable<CategoriesListingResponseModel> categories;

        protected override async Task OnInitializedAsync()
            => this.categories = await this.CategoriesService.All();

        private async Task SubmitAsync()
        {
            var result = await this.CategoriesService.CreateAsync(this.model,"aaaa");

            //var result = id;
            if (result.Succeeded)
            {
                this.ToastService.ShowSuccess("تم إضافة الفئة");
            }
            else
            {
                this.NavigationManager.NavigateTo($"/categories/addcat");
            }
            
        }


        //private async Task HandleSelection(IFileListEntry[] files)
        //{
        //    var file = files.FirstOrDefault();
        //    if (file != null)
        //    {
        //        // Just load into .NET memory to show it can be done
        //        // Alternatively it could be saved to disk, or parsed in memory, or similar
        //        var ms = new MemoryStream();
        //        await file.Data.CopyToAsync(ms);

        //        status = $"Finished loading {file.Size} bytes from {file.Name}";
        //    }
        //}


        //string status;
        //async Task HandleSelection(IFileListEntry[] files)
        //{
        //    var file = files.FirstOrDefault();
        //    if (file != null)
        //    {
        //        // Just load into .NET memory to show it can be done
        //        // Alternatively it could be saved to disk, or parsed in memory, or similar
        //        var ms = new MemoryStream();
        //        await file.Data.CopyToAsync(ms);

        //        status = $"Finished loading {file.Size} bytes from {file.Name}";
        //        var content = new MultipartFormDataContent
        //    {
        //        {new ByteArrayContent(ms.GetBuffer()),"\"upload\"",file.Name }
        //    };
        //        await client.PostAsync("upload", content);
        //    }
        //}

    }
}
