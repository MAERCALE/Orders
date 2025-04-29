using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orders.Shared.Interfaces;

namespace Orders.Shared.Entites
{
    public class State : IEntityWithName
    {
        public int Id { get; set; }

        [Display(Name = "Departamento")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Name { get; set; } = null!;
        public int CountryId { get; set; }
        public Country? Country { get; set; }
        public ICollection<City>? Cities { get; set; } //Establece la relación 1-* con City

        [Display(Name = "Distritos")]
        public int CitiesNumber => Cities == null || Cities.Count == 0 ? 0 : Cities.Count; //obtieene el número de departamentos existentes
    }
}
