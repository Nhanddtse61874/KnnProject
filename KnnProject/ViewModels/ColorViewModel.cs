using System.ComponentModel.DataAnnotations;

namespace KnnProject.ViewModels
{
    public class ColorViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class CreateColorViewModel
    {
        [Required]
        public string Name { get; set; }
    }

    public class UpdateColorViewModel
    {
        [Required]
        public int Id { get; set; }


        [Required]
        public string Name { get; set; }
    }
}