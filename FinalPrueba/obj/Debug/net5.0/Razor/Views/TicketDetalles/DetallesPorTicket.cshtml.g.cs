#pragma checksum "C:\Users\agust\source\repos\FinalPrueba\FinalPrueba\Views\TicketDetalles\DetallesPorTicket.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "21ad121620479d703945783bddc48074101d4235"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_TicketDetalles_DetallesPorTicket), @"mvc.1.0.view", @"/Views/TicketDetalles/DetallesPorTicket.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\agust\source\repos\FinalPrueba\FinalPrueba\Views\_ViewImports.cshtml"
using FinalPrueba;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\agust\source\repos\FinalPrueba\FinalPrueba\Views\_ViewImports.cshtml"
using FinalPrueba.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"21ad121620479d703945783bddc48074101d4235", @"/Views/TicketDetalles/DetallesPorTicket.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1ffbbe78e5dca739081a4096ec02832e8498fd21", @"/Views/_ViewImports.cshtml")]
    public class Views_TicketDetalles_DetallesPorTicket : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<FinalPrueba.Models.TicketDetalle>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\agust\source\repos\FinalPrueba\FinalPrueba\Views\TicketDetalles\DetallesPorTicket.cshtml"
  
    ViewData["Title"] = "DetallesPorTicket";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>Detalles de Ticket Pendientes de Resolución</h1>


<table class=""table"">
    <thead>
        <tr>
            <th>Descripción de Pedido</th>
            <th>Estado</th>
            <th>Fecha de estado</th>
            <!-- Agrega aquí otros encabezados de columna si es necesario -->
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 19 "C:\Users\agust\source\repos\FinalPrueba\FinalPrueba\Views\TicketDetalles\DetallesPorTicket.cshtml"
         foreach (var detalle in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 22 "C:\Users\agust\source\repos\FinalPrueba\FinalPrueba\Views\TicketDetalles\DetallesPorTicket.cshtml"
               Write(detalle.descripcionPedido);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 23 "C:\Users\agust\source\repos\FinalPrueba\FinalPrueba\Views\TicketDetalles\DetallesPorTicket.cshtml"
                Write(detalle.estado.resolucion ? "Resuelto" : "No Resuelto");

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 24 "C:\Users\agust\source\repos\FinalPrueba\FinalPrueba\Views\TicketDetalles\DetallesPorTicket.cshtml"
               Write(detalle.fechaEstado);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <!-- Agrega aquí otras columnas de detalles según tus necesidades -->\r\n            </tr>\r\n");
#nullable restore
#line 27 "C:\Users\agust\source\repos\FinalPrueba\FinalPrueba\Views\TicketDetalles\DetallesPorTicket.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<FinalPrueba.Models.TicketDetalle>> Html { get; private set; }
    }
}
#pragma warning restore 1591
