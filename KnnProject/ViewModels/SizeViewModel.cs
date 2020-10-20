using System.ComponentModel.DataAnnotations;

namespace KnnProject.ViewModels
{
    public class SizeViewModel
    {
        
        public int Id { get; set; }


        public string Name { get; set; }

        
    }
    public class CreateSizeViewModel
    {
        [Required]
        public int Id { get; set; }


        [Required][MaxLength(255)]
        public string Name { get; set; }
    }

    public class UpdateSizeViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required][MaxLength(255)]
        public string Name { get; set; }
    }
}