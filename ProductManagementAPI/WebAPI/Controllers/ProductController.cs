using AutoMapper;
using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/product/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _IMapper;
        private readonly IProduct _IProduct;
        private readonly IServiceProduct _IServiceProduct;

        public ProductController(IMapper iMapper, IProduct iProduct, IServiceProduct iServiceProduct)
        {
            _IMapper = iMapper;
            _IProduct = iProduct;
            _IServiceProduct = iServiceProduct;
        }

        private async Task<string> GetLoggedUserId()
        {
            if (User != null)
            {
                var idUser = User.FindFirst("idUser");

                if (idUser != null)
                    return idUser.Value;
            }

            return string.Empty;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/product/Add")]
        public async Task<List<Notifies>> Add(ProductViewModel product)
        {
            product.UserId = await GetLoggedUserId();
            var productMap = _IMapper.Map<Product>(product);
            await _IServiceProduct.Add(productMap);
            return productMap.Notifications;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/product/Update")]
        public async Task<List<Notifies>> Update(ProductViewModel product)
        {
            product.UserId = await GetLoggedUserId();
            var productMap = _IMapper.Map<Product>(product);
            await _IServiceProduct.Update(productMap);
            return productMap.Notifications;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/product/Delete")]
        public async Task<List<Notifies>> Delete(ProductViewModel product)
        {
            product.UserId = await GetLoggedUserId();
            var productMap = _IMapper.Map<Product>(product);
            await _IServiceProduct.Delete(productMap);
            return productMap.Notifications;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/product/GetEntityById")]
        public async Task<ProductViewModel> GetEntityById(ProductViewModel product)
        {
            var ret = await _IProduct.GetEntityById(product.Id);
            var productMap = _IMapper.Map<ProductViewModel>(ret);
            return productMap;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/product/List")]
        public async Task<List<ProductViewModel>> List()
        {
            var products = await _IProduct.List();
            var productMap = _IMapper.Map<List<ProductViewModel>>(products);
            return productMap;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/product/ListActivesProducts")]
        public async Task<List<ProductViewModel>> ListActivesProducts()
        {
            var products = await _IServiceProduct.ListActivesProducts();
            var productMap = _IMapper.Map<List<ProductViewModel>>(products);
            return productMap;
        }
    }
}
