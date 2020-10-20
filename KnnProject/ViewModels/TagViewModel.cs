using System.ComponentModel.DataAnnotations;

namespace KnnProject.ViewModels
{
    public class TagViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        
    }

    public class CreateTagViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required][MaxLength(255)]
        public string Name { get; set; }

    }

    public class UpdateTagViewModel
    {
        [Required]
        public int Id { get; set; }


        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

    }


}