using Microsoft.AspNetCore.Mvc;
using PurpleBuzz.DataBase;
using PurpleBuzz.Models.Pricing;

namespace PurpleBuzz.Controllers
{
    public class PricingController : Controller
    {
        private readonly AppDBContext _appDBContext;
        public PricingController(AppDBContext context)
        {
            _appDBContext = context;
        }
        public IActionResult Index()
        {
            var Prices = _appDBContext.Prices.ToList();
            var PricesList = new List<PriceVM>();
            foreach (var price in Prices)
            {
                var priceVM = new PriceVM
                {
                    Name = price.Name,
                    PricePlan = price.PricePlan,
                    Item1 = price.Item1,
                    Item2 = price.Item2,
                    Item3 = price.Item3,
                    Item4 = price.Item4,
                    Item5 = price.Item5
                };
                PricesList.Add(priceVM);
            }
            var model = new PricingIndexVM
            {
                Prices = PricesList
            };
            return View(model);
        }
    }
}
