using Assignment.Domain;
using Assignment.UI.Models;
using Mapster;
using Microsoft.Identity.Client;

namespace Assignment.UI.Mapping
{

        public class MappingConfig : IRegister
        {
            public void Register(TypeAdapterConfig config)
            {
                config.NewConfig<ProductModel, ProductDomain>();

           
            }
        
    }
}
