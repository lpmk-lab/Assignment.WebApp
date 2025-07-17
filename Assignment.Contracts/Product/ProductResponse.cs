using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Contracts.Product
{
    record class ProductResponse
    (
      int Id, string Name, string Description,DateTime CreatedDate
    );
}
