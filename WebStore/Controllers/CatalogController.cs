using Microsoft.AspNetCore.Mvc;
using WebStore.Domain;
using WebStore.Services.Interfaces;
using WebStore.ViewModels;

namespace WebStore.Controllers;

public class CatalogController : Controller
{
    private readonly IProductData _ProductData;

    public CatalogController(IProductData ProductData) => _ProductData = ProductData;

    public IActionResult Index(int? SectionId, int? BrandId)
    {
        var filter = new ProductFilter
        {
            SectionId = SectionId,
            BrandId = BrandId,
        };

        var products = _ProductData.GetProducts(filter);

        return View(new CatalogViewModel
        {
            SectionId = SectionId,
            
            BrandId = BrandId,

            Products = products
            .OrderBy(x => x.Order)
            .Select(x => new ProductViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                ImageUrl = x.ImageUrl,
            }),
        });
    }
}

