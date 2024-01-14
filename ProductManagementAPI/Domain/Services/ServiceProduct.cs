using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;

namespace Domain.Services
{
    public class ServiceProduct : IServiceProduct
    {
        private readonly IProduct _IProduct;
        private readonly ISponsor _ISponsor;

        public ServiceProduct(IProduct iProduct, ISponsor iSponsor)
        {
            _IProduct = iProduct;
            _ISponsor = iSponsor;
        }

        public async Task Add(Product product)
        {
            var isValid = product.ValidateStringValue(product.Description, "Description");
            isValid = isValid ? product.ValidateDateValue(product.ManufacturingDate, "ManufacturingDate") : isValid;
            isValid = isValid ? product.ValidateDateValue(product.BestBeforeAt, "BestBeforeAt") : isValid;
            isValid = isValid ? product.ValidateBetweenTwoDateValue(product.ManufacturingDate, product.BestBeforeAt, "ManufacturingDate", "Data de fabricação não pode ser menor ou igual data de validade.") : isValid;
            if (isValid)
            {
                product.CreatedAt = DateTime.Now;
                product.UpdatedAt = DateTime.Now;
                product.Active = true;
                await _IProduct.Add(product);
            }
        }

        public async Task Update(Product product)
        {
            var isValid = product.ValidateStringValue(product.Description, "Description");
            isValid = isValid ? product.ValidateDateValue(product.ManufacturingDate, "ManufacturingDate") : isValid;
            isValid = isValid ? product.ValidateDateValue(product.BestBeforeAt, "BestBeforeAt") : isValid;
            isValid = isValid ? product.ValidateBetweenTwoDateValue(product.ManufacturingDate, product.BestBeforeAt, "ManufacturingDate", "Data de fabricação não pode ser menor ou igual data de validade.") : isValid;
            if (isValid)
            {
                if (product != null && product.Id > 0)
                {
                    Product data = await _IProduct.GetEntityById(product.Id);

                    if (data != null)
                    {
                        data.Description = product.Description;
                        data.ManufacturingDate = product.ManufacturingDate;
                        data.BestBeforeAt = product.BestBeforeAt;
                        data.SponsorId = product.SponsorId;
                        data.UpdatedAt = DateTime.Now;

                        await _IProduct.Update(data);
                    }
                }
            }
        }

        public async Task Delete(Product product)
        {
            if (product != null && product.Id > 0)
            {
                Product data = await _IProduct.GetEntityById(product.Id);

                if (data != null)
                {
                    data.Active = false;
                    data.DeletedAt = DateTime.Now;
                    await _IProduct.Update(data);
                }
            }
        }

        public async Task<List<Product>> ListActivesProducts(int id, string description, int pageIndex, int pageSize)
        {
            List<Product> products = await _IProduct.ListProducts(
                n => (n.Id == id || id == 0)
                    && (n.Description.Contains(description) || string.IsNullOrWhiteSpace(description))
                    && n.Active,
                pageIndex, pageSize);

            foreach (Product product in products)
            {
                if (product.SponsorId > 0)
                    product.Sponsor = await _ISponsor.GetEntityById(product.SponsorId);
            }

            return products;
        }
    }
}
