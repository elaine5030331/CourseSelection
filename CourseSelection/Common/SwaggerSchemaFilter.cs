using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CourseSelection.Common
{
    public class SwaggerSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type == typeof(TimeOnly))
            {
                schema.Type = "string";
                schema.Format = "time";
                schema.Example = new OpenApiString("09:00:00");
            }

            if (context.Type == typeof(TimeSpan))
            {
                schema.Type = "string";
                schema.Format = "time";
                schema.Example = new OpenApiString("09:00:00");
            }
        }
    }
}
