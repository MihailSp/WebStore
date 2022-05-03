using WebStore.Services.Interfaces;
using WebStore.Domain;
using WebStore.Domain.Entities;
using WebStore.Data;

namespace WebStore.Services
{
    public class InMemoryProductData : IProductData
    {       
        public IEnumerable<Section> GetSections() => TestData.Sections;

        public IEnumerable<Brand> GetBrands() => TestData.Brands;

        public IEnumerable<Product> GetProducts(ProductFilter? Filter = null)
        {
            IEnumerable<Product> query = TestData.Products;

            //if (Filter != null && Filter.SectionId != null)
            //    query = query.Where(x => x.SectionId == Filter.SectionId);

            if(Filter?.SectionId is { } section_id)
                query = query.Where(x => x.SectionId == section_id);

            if (Filter?.BrandId is { } brand_id)
                query = query.Where(x => x.BrandId == brand_id);

            return query;
        }

    }
}
