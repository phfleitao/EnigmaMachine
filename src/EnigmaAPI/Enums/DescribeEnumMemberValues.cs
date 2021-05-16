using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;
using System.Runtime.Serialization;

namespace EnigmaAPI.Enums
{
    public class DescribeEnumMemberValues : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type.IsEnum)
            {
                schema.Enum.Clear();
                var enumMembers = context.Type.GetMembers()
                                            .Where(t => t.DeclaringType.IsEnum == true && t.Name != "value__");

                foreach (var member in enumMembers)
                {
                    var memberCustomAttr = member.GetCustomAttributes(typeof(EnumMemberAttribute), false).FirstOrDefault();
                    if (memberCustomAttr != null)
                    {
                        var attr = (EnumMemberAttribute)memberCustomAttr;
                        schema.Enum.Add(new OpenApiString(attr.Value));
                    }
                    else
                    {
                        schema.Enum.Add(new OpenApiString(member.Name));
                    }
                }
            }
        }
    }
}
