using SGU_C2CStore.Models;
using SGU_C2CStore.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

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
            Auction auction = proxy.GetAuction(id.Value);
            List<Auction> relativeAutions = proxy.GetOpenAuctionsByUser(auction.Item.Owner.Email, 0, 10).ToList();
            proxy.Close();
            if (auction == null)
            {
                return HttpNotFound();
            }
            ViewData["OtherAutions"] = relativeAutions;
            return View(auction);
        }

        [HttpPost]
        public ActionResult Bid(string returnUrl)
        {
            var autionId = int.Parse(Request["Id"]);
            var user = Request["User"];
            var status = false;
            if (User.Identity.IsAuthenticated)
            {
                ApplicationDbContext db = new ApplicationDbContext();
                var email = db.Users.Where(e => e.UserName == user).FirstOrDefault().Email;
                var price = int.Parse(Request["Price"]);
                var proxy = new AuctionServiceClient("BasicHttpBinding_IAuctionService");
                proxy.Open();
                status = proxy.Bid(email, price, autionId);
                proxy.Close();
            }
            return Redirect(returnUrl);
        }
    }
}