#pragma checksum "D:\LICENCIATURA EN INFORMATICA\2° AÑO\TALLER DE LENGUAJES 2\tpnro-6-Cristian021195\CadeteriaRemake\Views\Pedido\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1fe5a30ec93ba1361fbb4a4f6a5f427fde924920"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Pedido_Index), @"mvc.1.0.view", @"/Views/Pedido/Index.cshtml")]
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
#line 1 "D:\LICENCIATURA EN INFORMATICA\2° AÑO\TALLER DE LENGUAJES 2\tpnro-6-Cristian021195\CadeteriaRemake\Views\_ViewImports.cshtml"
using CadeteriaRemake;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\LICENCIATURA EN INFORMATICA\2° AÑO\TALLER DE LENGUAJES 2\tpnro-6-Cristian021195\CadeteriaRemake\Views\_ViewImports.cshtml"
using CadeteriaRemake.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1fe5a30ec93ba1361fbb4a4f6a5f427fde924920", @"/Views/Pedido/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"445b3c18bfda8c3f3fee81659d3d7ddd9bdbb062", @"/Views/_ViewImports.cshtml")]
    public class Views_Pedido_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<CadeteriaRemake.ViewModels.PedidoViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"    <div class=""row"">
        <div class=""col-md-10 mx-auto"">
            <table class=""table table-striped"">
                <tr>
                    <th>Id</th>
                    <th>Observacion</th>
                    <th>Tipo</th>
                    <th>Estado</th>
                    <th>Cupon</th>
                    <th>Cliente</th>
                    <th>Cadete</th>
                    <th>Costo</th>
                </tr>
");
#nullable restore
#line 15 "D:\LICENCIATURA EN INFORMATICA\2° AÑO\TALLER DE LENGUAJES 2\tpnro-6-Cristian021195\CadeteriaRemake\Views\Pedido\Index.cshtml"
                 foreach (var pedido in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>");
#nullable restore
#line 18 "D:\LICENCIATURA EN INFORMATICA\2° AÑO\TALLER DE LENGUAJES 2\tpnro-6-Cristian021195\CadeteriaRemake\Views\Pedido\Index.cshtml"
                       Write(pedido.numero);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 19 "D:\LICENCIATURA EN INFORMATICA\2° AÑO\TALLER DE LENGUAJES 2\tpnro-6-Cristian021195\CadeteriaRemake\Views\Pedido\Index.cshtml"
                       Write(pedido.observacion);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 20 "D:\LICENCIATURA EN INFORMATICA\2° AÑO\TALLER DE LENGUAJES 2\tpnro-6-Cristian021195\CadeteriaRemake\Views\Pedido\Index.cshtml"
                       Write(pedido.tipoPedido);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 21 "D:\LICENCIATURA EN INFORMATICA\2° AÑO\TALLER DE LENGUAJES 2\tpnro-6-Cristian021195\CadeteriaRemake\Views\Pedido\Index.cshtml"
                       Write(pedido.estado_pedido);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 22 "D:\LICENCIATURA EN INFORMATICA\2° AÑO\TALLER DE LENGUAJES 2\tpnro-6-Cristian021195\CadeteriaRemake\Views\Pedido\Index.cshtml"
                       Write(pedido.cupon);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 23 "D:\LICENCIATURA EN INFORMATICA\2° AÑO\TALLER DE LENGUAJES 2\tpnro-6-Cristian021195\CadeteriaRemake\Views\Pedido\Index.cshtml"
                       Write(pedido.cliente.Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 24 "D:\LICENCIATURA EN INFORMATICA\2° AÑO\TALLER DE LENGUAJES 2\tpnro-6-Cristian021195\CadeteriaRemake\Views\Pedido\Index.cshtml"
                       Write(pedido.cadete.Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 25 "D:\LICENCIATURA EN INFORMATICA\2° AÑO\TALLER DE LENGUAJES 2\tpnro-6-Cristian021195\CadeteriaRemake\Views\Pedido\Index.cshtml"
                       Write(pedido.costo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n");
#nullable restore
#line 27 "D:\LICENCIATURA EN INFORMATICA\2° AÑO\TALLER DE LENGUAJES 2\tpnro-6-Cristian021195\CadeteriaRemake\Views\Pedido\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </table>\r\n        </div>\r\n    </div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<CadeteriaRemake.ViewModels.PedidoViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
