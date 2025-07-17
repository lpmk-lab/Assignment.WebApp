using Assignment.Application.Service.Product.Common;
using Assignment.Domain;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Application.Service.Product.Queries.GetAllProductQuery
{
    public record GetAllProductQuery() : IRequest<ErrorOr<IEnumerable<ProductDomain>>>;
}
