using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Cars.Application.ViewModels.CarType
{
    public class CarTypeViewModel
    {
        [Key]
        public long IdN { get; set; }
        public Guid Id { get; set; }

        [DisplayName("MainImg")]
        public string MainImg { get; set; }


        [Required(ErrorMessage = "The Code is Required")]
        [MinLength(2)]
        [MaxLength(25)]
        [DisplayName("Code")]
        public string Code { get; set; }

        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("IsActive")]
        public bool IsActive { get; set; }

        [DisplayName("IsDeleted")]
        public bool IsDeleted { get; set; }

       
    }
}
