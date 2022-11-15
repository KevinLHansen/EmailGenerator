using BlazorTemplater;
using EmailGenerator.Components.Emails;
using EmailGenerator.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.RenderTree;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;

namespace EmailGenerator.Controllers
{
    public class EmailController : ApiController
    {
        private readonly IServiceProvider _ServiceProvider;

        public EmailController(IServiceProvider serviceProvider)
        {
            _ServiceProvider = serviceProvider;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmail([FromQuery] string? param)
        {
            var html = new ComponentRenderer<WelcomeEmail>()
                .AddServiceProvider(_ServiceProvider)
                .Set(x => x.QueryParamString, param ?? "")
                .Render();

            return Content(html, "text/html", Encoding.UTF8);
        }
    }
}
