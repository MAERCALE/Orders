using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orders.Shared.Interfaces;

namespace Orders.Shared.Entites
{
    public class City : IEntityWithName
    {
        public int Id { get; set; }

        [Display(Name = "Distrito")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Name { get; set; } = null!;
        public int StateId { get; set; }
        public State? State { get; set; }

    }
}
