#pragma checksum "C:\Projects\hr\Hr\Hr\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "32f53a7ad746da68747a09f3ab2701b98b8e8eb8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Projects\hr\Hr\Hr\Views\_ViewImports.cshtml"
using Hr;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Projects\hr\Hr\Hr\Views\_ViewImports.cshtml"
using Hr.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"32f53a7ad746da68747a09f3ab2701b98b8e8eb8", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d1a5cfc31d6e3bf7420ffc1939552c60fdf9417f", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n\r\n<style>\r\n    .fullpage-container {\r\n        position: absolute;\r\n        left: 0;\r\n        top: 0;\r\n        width: 100%;\r\n        height: 100%;\r\n    }\r\n</style>\r\n");
            WriteLiteral(@"

<div id=""app"">
    <template>
        <div class=""fullpage-container"">
            <div class=""fullpage-wp"" v-fullpage=""opts"">
                <div class=""page-1 page"">
                    <div class=""img-back"">
                    </div>
                    <div class=""img-back2"">
                    </div>
                    <div class=""textpage"" v-animate=""{value: 'fadeInDown',delay: 300}"">
                        <h3 class=""part-1"">_Ищем сотрудника в Cnails</h3>
                        <div class=""buttoms"" v-animate=""{value: 'fadeInDown',delay: 0}"">
                            <button> <span>Отправить</span> <span>резюме</span></button>
                            
                        </div>


");
            WriteLiteral(@"                    </div>




                </div>
                <div class=""page-2 page"">
                    <div>
                        <h3 class=""part-2"" v-animate=""{value: 'fadeInRight',delay: 0}"">Наша компания</h3>
                        <p class=""part-2"" v-animate=""{value: 'fadeInRight',delay: 300}"">
                            Бла-бла,круты,лидеры рынка
                        </p>
                        <p class=""part-2"" v-animate=""{value: 'fadeInRight',delay: 400}"">
                            Нами пользуются
                        </p>
                        <button class=""part-2"" v-animate=""{value: 'fadeInRight',delay: 600}"">Факты</button>
                    </div>
                </div>
                <div class=""page-3 page"">
                    <div class=""textpage-page3"" v-animate=""{value: 'fadeInUp'}"">
                        <h3>Заполни заявку</h3>
");
#nullable restore
#line 60 "C:\Projects\hr\Hr\Hr\Views\Home\Index.cshtml"
                         using (Html.BeginForm("Show", "Home", FormMethod.Post))
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            <div class=""form"">

                                <div class=""labels"">


                                    <label for=""name"">Имя</label>

                                    <label for=""fio"">Фамилия</label>
                                    <label for=""Number"">Number</label>
                                    <label for=""mail"">Почта</label>
                                    <label for=""name"">О себе</label>


                                </div>
                                <div class=""inputs"">
                                    <input name=""name"" type=""text""");
            BeginWriteAttribute("value", " value=\"", 2874, "\"", 2882, 0);
            EndWriteAttribute();
            WriteLiteral(" />\r\n                                    <input name=\"SurName\" type=\"text\"");
            BeginWriteAttribute("value", " value=\"", 2957, "\"", 2965, 0);
            EndWriteAttribute();
            WriteLiteral(" />\r\n                                    <input name=\"Number\" type=\"text\"");
            BeginWriteAttribute("value", " value=\"", 3039, "\"", 3047, 0);
            EndWriteAttribute();
            WriteLiteral(" />\r\n                                    <input name=\"mail\" type=\"text\"");
            BeginWriteAttribute("value", " value=\"", 3119, "\"", 3127, 0);
            EndWriteAttribute();
            WriteLiteral(" />\r\n                                    <input name=\"other\" type=\"text\"");
            BeginWriteAttribute("value", " value=\"", 3200, "\"", 3208, 0);
            EndWriteAttribute();
            WriteLiteral(" />\r\n                                </div>\r\n\r\n\r\n                            </div>\r\n                            <input type=\"submit\" value=\"Отправить\" />\r\n");
#nullable restore
#line 87 "C:\Projects\hr\Hr\Hr\Views\Home\Index.cshtml"

                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                    </div>\r\n                    \r\n\r\n");
            WriteLiteral("                </div>\r\n            </div>\r\n        </div>\r\n");
            WriteLiteral("    </template>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
