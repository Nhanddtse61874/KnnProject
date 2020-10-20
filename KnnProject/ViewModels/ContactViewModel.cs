using System.ComponentModel.DataAnnotations;

namespace KnnProject.ViewModels
{
    public class ContactViewModel
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public int Phone { get; set; }

        public string Description { get; set; }
    }

    public class CreateContactViewModel
    {
        [Required, MaxLength(255)]
        public string Name { get; set; }


        [Required, MaxLength(255)]
        public string Address { get; set; }


        [Required]
        public int Phone { get; set; }


        [Required, MaxLength(255)]
        public string Description { get; set; }
    }

    public class UpdateContactViewModel
    {
        [Required]
        public int Id { get; set; }


        [Required, MaxLength(255)]
        public string Name { get; set; }


        [Required, MaxLength(255)]
        public string Address { get; set; }


        [Required]
        public int Phone { get; set; }


        [Required, MaxLength(255)]
        public string Description { get; set; }
    }
}