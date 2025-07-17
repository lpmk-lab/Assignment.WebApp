


using ErrorOr;

namespace Assignment.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class Product
        {
            public static Error DuplicateName => Error.Conflict(code: "Product.DuplicateName", description: "Name is already in use.");
            public static Error DBError => Error.Unexpected(code: "Product.DBError", description: "Error Processing in DB");
            public static Error NotFound => Error.NotFound(code: "Product.NotFound", description: "Product Not Found");
            public static Error InputFail => Error.NotFound(code: "Product.InputFail", description: "Input Data Failed");
        }
    }

}