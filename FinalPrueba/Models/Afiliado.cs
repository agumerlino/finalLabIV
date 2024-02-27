using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalPrueba.Models
{
    public class Afiliado
    {
        public int Id { get; set; }

        public string nombre { get; set; }

        public string apellido { get; set; }

        public int dni { get; set; }

        public DateTime fechaNacimiento { get; set; }

        public string? foto { get; set; }

        public string nombreCompleto => $"{nombre} {apellido}";

    }
}
