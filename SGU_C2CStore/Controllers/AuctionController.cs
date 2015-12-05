using SGU_C2CStore.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SGU_C2CStore.Controllers
{
    public class AuctionController : Controller
    {
        // GET: Auction
        public ActionResult Index()
        {
            List<Auction> items;
            var proxy = new AuctionServiceClient("BasicHttpBinding_IAuctionService");
            proxy.Open();
            items = proxy.GetOpenAuctions().OrderBy(e => e.StartTime).ToList();
            List<string> categories = items.GroupBy(e => e.Item.Category.Name).Select(e => e.Key).Distinct().ToList();
            ViewData["groups"] = categories;
            proxy.Close();
            return View(items);
        }

        
    }
}