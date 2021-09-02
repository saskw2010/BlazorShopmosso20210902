namespace BlazorShop.Models.Categories
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Hosting;
    using static ErrorMessages;
    using static Data.ModelConstants.Common;
    using static Data.ModelConstants.Category;

    public class CategoriesRequestModel
    {
        //private readonly IWebHostEnvironment environment;
        //public string imagepath;
        //public UploadController(IWebHostEnvironment environment)
        //{
        //    this.environment = environment;
        //}

        [Required]
        [StringLength(
            MaxNameLength, 
            ErrorMessage = StringLengthErrorMessage, 
            MinimumLength = MinNameLength)]
        public string Name { get; set; }

        //[Required]
        [MaxLength(MaxUrlLength)]
        public string ImageSource { get; set; }

        public string path { get; set; } 
    }
}
