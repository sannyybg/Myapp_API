using DbProvider;
using DbProvider.VirtualDTO;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tt1ap.ExtensionMethods
{
    public static class MyExtension
    {
        public static void AddSwaggerConfig(this IServiceCollection services)
        {
            var apiVersionProvider = services.BuildServiceProvider().GetService<IApiVersionDescriptionProvider>();

            services.AddSwaggerGen(options =>
            {
                foreach (var item in apiVersionProvider.ApiVersionDescriptions)
                {
                    options.SwaggerDoc(
                        $"LibraryOpenAPISpecification{item.GroupName}",
                        new Microsoft.OpenApi.Models.OpenApiInfo()
                        {
                            Title = "Company Managment Api",
                            Version = item.ApiVersion.ToString(),
                            Description = "API for Companies"
                        });
                }

                options.DocInclusionPredicate((docName, apiDescr) =>
                {
                    var actionApiVersionModel = apiDescr.ActionDescriptor
                    .GetApiVersionModel(ApiVersionMapping.Explicit | ApiVersionMapping.Implicit);

                    if (actionApiVersionModel == null)
                    {
                        return true;
                    }

                    if (actionApiVersionModel.DeclaredApiVersions.Any())
                    {
                        return actionApiVersionModel.DeclaredApiVersions.Any(v =>
                        $"LibraryOpenAPISpecificationv{v.ToString()}" == docName);
                    }

                    return actionApiVersionModel.DeclaredApiVersions.Any(v =>
                    $"LibraryOpenAPISpecificationv{v.ToString()}" == docName);

                });

            });
        }

    }
}
