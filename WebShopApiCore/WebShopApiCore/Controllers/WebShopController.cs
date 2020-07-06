using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebShopApiCore.DTO;
using WebShopApiCore.Models;
using WebShopApiCore.Repository;

namespace WebShopApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CORS_Policy")]
    public class WebShopController : ControllerBase
    {
        private IWebShopRepository _webshopRepository;

        public WebShopController(IWebShopRepository webshopRepository)
        {
            _webshopRepository = webshopRepository;
        }

        [HttpGet]
        [Route("items")]
        public ActionResult<IEnumerable<ItemDTO>> GetItems()
        {
            return _webshopRepository.GetItems().ToList();
        }

        [HttpGet]
        [Route("final-cost-promotions")]
        public ActionResult<IEnumerable<FinalCostPromotionDTO>> GetFinalCostPromotions()
        {
            return _webshopRepository.GetFinalCostPromotions().ToList();
        }

        [HttpGet]
        [Route("item-quantity-promotions")]
        public ActionResult<IEnumerable<ItemQuantityPromotionDTO>> GetItemQuantityPromotions()
        {
            return _webshopRepository.GetItemQuantityPromotions().ToList();
        }

        [HttpPost]
        [Route("calculate-price")]
        public ActionResult<decimal> CalculatePrice([FromBody] BasketDTO basket)
        {
            return _webshopRepository.CalculatePrice(basket);
        }

        [HttpPost]
        [Route("save-customer")]
        public ActionResult<int> SaveCustomer([FromBody] CustomerDTO customer)
        {
            return _webshopRepository.SaveCustomer(customer);
        }

        [HttpPost]
        [Route("save-order")]
        public ActionResult<int> SaveOrder([FromBody] BasketDTO basket)
        {
            return _webshopRepository.SaveOrder(basket);
        }
    }
}