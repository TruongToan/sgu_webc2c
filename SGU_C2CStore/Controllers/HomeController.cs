using SGU_C2CStore.Models;
using SGU_C2CStore.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SGU_C2CStore.Controllers
{
    public class HomeController : Controller
    {
        // GET: Auction
        public ActionResult Index(string Id)
        {
            var keyword = Request["keyword"];
            ViewBag.Type = Id;
            List<Auction> items;

            var proxy = new AuctionServiceClient("BasicHttpBinding_IAuctionService");
            proxy.Open();
            items = proxy.GetOpenAuctionsByCategory(Id, 0, 10).ToList();
            ViewData["groups"] = proxy.GetAllCategories().Select(e => e.Name).ToList();
            proxy.Close();
            return View(items);
        }

        public ActionResult Hot(string Id)
        {
            var keyword = Request["keyword"];
            ViewBag.Type = Id;
            List<Auction> items;

            var proxy = new AuctionServiceClient("BasicHttpBinding_IAuctionService");
            proxy.Open();
            items = proxy.GetTopBidAuctionsByCategory(Id, 0, 10).ToList();
            ViewData["groups"] = proxy.GetAllCategories().Select(e => e.Name).ToList();
            proxy.Close();
            return View(items);
        }

        public ActionResult Special(string Id)
        {
            var keyword = Request["keyword"];
            ViewBag.Type = Id;
            List<Auction> items;

            var proxy = new AuctionServiceClient("BasicHttpBinding_IAuctionService");
            proxy.Open();
            items = proxy.GetTopPriceAuctionsByCategory(Id, 0, 10).ToList();
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
            List<Auction> relativeAutions = proxy.GetOpenAuctionsByUser(auction.Owner.Email, 0, 10).ToList();
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
        [HttpPost]
        public ActionResult Comment(string returnUrl)
        {
            var autionId = int.Parse(Request["Id"]);
            if (User.Identity.IsAuthenticated)
            {
                ApplicationDbContext db = new ApplicationDbContext();
                var email = db.Users.Where(e => e.UserName == User.Identity.Name).FirstOrDefault().Email;
                var cmt = Request["Comment"];
                var proxy = new AuctionServiceClient("BasicHttpBinding_IAuctionService");
                proxy.Open();
                proxy.Comment(email, autionId, cmt);
                proxy.Close();
            }
            return Redirect(returnUrl);
        }

        [HttpPost]
        public ActionResult Contact(ContactModel model)
        {
            if (ModelState.IsValid)
            {
                string smtpUserName = "thlogn@gmail.com";
                string smtpPassword = "dvhmmbnspexgspsr";
                string smtpHost = "smtp.gmail.com";
                int smtpPort = 587;

                string emailTo = "thanhlong.itsgu@gmail.com";
                string subject = model.Subject;
                string body = string.Format("Bạn vừa nhận được liên hệ từ: <b>{0}</b><br/>Email: {1}<br/>Nội dung: </br>{2}",
                    model.UserName, model.Email, model.Message);

                EmailService service = new EmailService();

                bool kq = service.Send(smtpUserName, smtpPassword, smtpHost, smtpPort,
                    emailTo, subject, body);

                if (kq) ModelState.AddModelError("", "Cảm ơn bạn đã liên hệ với chúng tôi.");
                else ModelState.AddModelError("", "Gửi tin nhắn thất bại, vui lòng thử lại.");
            }
            return View(model);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}