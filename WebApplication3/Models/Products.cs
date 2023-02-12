using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Products
    {
        public Products()
        {
            Id = Guid.NewGuid();
        }
        [Display(Name = "کد محصول")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [Key]
        public Guid Id { get; set; }
        [Display(Name = "نام محصول ")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        
        public string Name { get; set; }
        [Display(Name = "ردیف محصول")]
        [Required(ErrorMessage = "{0} را وارد کنید")]

        public int Row { get; set; }

    }
}