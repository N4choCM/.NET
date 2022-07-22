using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace APIVersionControl
{
    public class ConfigureSwaggerOptions : IConfigureNamedOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            _provider = provider;
        }

        private OpenApiInfo CreateVersionInfo(ApiVersionDescription description)
        {
            var info = new OpenApiInfo()
            {
                Title = "My .Net API Restful",
                Version = description.ApiVersion.ToString(),
                Description = "This is my first API Versioning control",
                Contact = new OpenApiContact()
                {
                    Email = "nachocamposmarti@gmail.com",
                    Name = "Nacho"
                }
            };

            if (description.IsDeprecated)
            {
                info.Description += "This API version has been deprecated";
            }

            return info;
        }
        
        public void Configure(SwaggerGenOptions options)
        {
            // Add Swagger documentation for each API version we have
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateVersionInfo(description));
            }
        }

        public void Configure(string name, SwaggerGenOptions options)
        {
            Configure(options);    
        }
    }
}
