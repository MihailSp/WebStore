using Microsoft.AspNetCore.Mvc;
using WebStore.Services.Interfaces;
using WebStore.ViewModels;

namespace WebStore.Components;

public class BrandsViewComponent : ViewComponent
{
    private readonly IProductData _ProductData;

    public BrandsViewComponent(IProductData ProductData) => _ProductData = ProductData;

    public IViewComponentResult Invoke() => View(GetBrends());

    private IEnumerable<BrendViewModel> GetBrends() => _ProductData.GetBrands()
        .OrderBy(b => b.Order)
        .Select(b => new BrendViewModel
        {
            Id = b.Id,
            Name = b.Name,
        });
}

