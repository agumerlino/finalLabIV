using FinalPrueba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace FinalPrueba.ViewModels
{
    public class AfiliadosViewModel
    {
        public IPagedList<Afiliado> Afiliados { get; set; }

        public string apellido { get; set; }

        public int dni { get; set; }
    }
}
