using Newtonsoft.Json;
using System.Diagnostics;

namespace API_Personnes2.Helpers
{
    static class ObjectsHelpers
    {
        public static void Dump(this object data)
        {
            string json = JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);
            Trace.WriteLine("");
            Trace.WriteLine(json);

            // installation, ajouter les packages :
            //     < PackageReference Include = "Microsoft.AspNetCore.JsonPatch" Version = "5.0.10" />
            //     < PackageReference Include = "Microsoft.AspNetCore.Mvc.NewtonsoftJson" Version = "5.0.10" />
            // ajouter la configuration dans startup
            //      services.AddControllers().AddNewtonsoftJson(s => {
            //      s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();});

            //Utilisation   objet.Dump();
        }
    }
}
