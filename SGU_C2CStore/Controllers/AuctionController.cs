using SGU_C2CStore.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SGU_C2CStore.Controllers
{
    public class AuctionController : Controller
    {
        // GET: Auction
        public ActionResult Index(string Id)
        {
            var keyword = Request["keyword"];
            ViewBag.Type = Id;
            List<Auction> items;

            var proxy = new AuctionServiceClient("BasicHttpBinding_IAuctionService");
            proxy.Open();
            items = proxy.GetOpenAuctionsByCategory(Id, 0,10).OrderBy(e => e.StartTime).ToList();
            ViewData["groups"] = proxy.GetAllCategories().Select(e => e.Name).ToList();
            proxy.Close();
            return View(items);
        }

        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var proxy = new AuctionServiceClient("BasicHttpBinding_IAuctionService");
            proxy.Open();
            Auction auction = null;
            proxy.Close();
            if (auction == null)
            {
                return HttpNotFound();
            }
            return View(auction);
        }
    }
}