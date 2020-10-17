using System.ComponentModel.DataAnnotations;

namespace KnnProject.ViewModels
{
    public class ImageStorageViewModel
    {
        public string ImageUrl { get; set; }

        public string Alt { get; set; }
    }

    public class CreateImageStorageViewModel
    {
        public CreateImageStorageViewModel(string alt, string imageUrl)
        {
            ImageUrl = imageUrl;
            Alt = alt;
        }

        [Required]
        public string ImageUrl { get; set; }

        [Required, MaxLength(255)]
        public string Alt { get; set; }
    }

    public class UpdateImageStorageViewModel
    {
        [Required]
        public int Id { get; set; }


        [Required]
        public string ImageUrl { get; set; }


        [Required]
        [MaxLength(255)]
        public string Alt { get; set; }

        [Required]
        public int ProductId { get; set; }
    }
}