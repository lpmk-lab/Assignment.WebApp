using Assignment.Application.Service.Product.Commands.CreateProductCommand;
using Assignment.Application.Service.Product.Commands.DeleteProductCommand;
using Assignment.Application.Service.Product.Queries.GetAllProductQuery;
using Assignment.Domain;
using Assignment.UI.Models;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;
        public ProductController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _mediator.Send(new GetAllProductQuery());

            if (result.IsError)
            {
                ViewBag.ErrorMessage = result.FirstError.Description;
            }

            var productModels = _mapper.Map<List<ProductModel>>(result.Value ?? new List<ProductDomain>());
            return View(productModels);
        }

        public async Task<IActionResult> Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductModel productModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(productModel);
                }
                var result = await _mediator.Send(new CreateProductCommand(productModel.Name, productModel.Description));
                if (!result.IsError)
                {
                    TempData["msg"] = "Successfully Added";
                }
                else{
                    TempData["msg"] = result.FirstError.Description;
                }
  
            }
            catch(Exception ex)
            {
                TempData["msg"] = "Could not Added";

            }
            return RedirectToAction(nameof(Add));
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ProductModel productModel)
        {
            return View();
        }


        public async Task<IActionResult> GetById(int id)
        {
            return View();
        }
        public async Task<IActionResult> DisplayAll()
        {
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteProductCommand(id));

            if (result.IsError)
            {
                ViewBag.ErrorMessage = result.FirstError.Description;
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
