using System;
using System.ComponentModel.DataAnnotations;
namespace MiApp.Web.Data.Entities
{
    public class ItemEntity
    {
        public int Id { get; set; }

        [Display(Name = "Item")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Name { get; set; }

        [Display(Name = "Logo")]
        public string LogoPath { get; set; }

        [Display(Name = "Activo")]
        public bool Active { get; set; }

        [Display(Name = "Fecha")]
        public DateTime Date { get; set; }

        [Display(Name = "Cantidad")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public int Quantity { get; set; }

        [Display(Name = "Precio")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public double Price { get; set; }
    }
}
