using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SGU_C2CStore.Models;
using SGU_C2CStore.Services.Models;

namespace SGU_C2CStore.Controllers
{
    [Authorize]
    public class AuctionController : Controller
    {
        // GET: Auction
        public ActionResult Index()
        {
            List<Auction> items;

            var proxy = new AuctionServiceClient("BasicHttpBinding_IAuctionService");
            proxy.Open();
            ApplicationDbContext db = new ApplicationDbContext();
            var email = db.Users.Where(e => e.UserName == User.Identity.Name).FirstOrDefault().Email;
            items = proxy.GetMyAuctions(email).ToList();
            ViewData["groups"] = proxy.GetAllCategories().Select(e => e.Name).ToList();
            proxy.Close();
            db.Dispose();
            return View(items);
        }

        // GET: Auction/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var proxy = new AuctionServiceClient("BasicHttpBinding_IAuctionService");
            proxy.Open();
            Auction auction = proxy.GetAuction(id.Value);
            proxy.Close();
            if (auction == null)
            {
                return HttpNotFound();
            }
            return View(auction);
        }

        // GET: Auction/Create
        public ActionResult Create()
        {
            var proxy = new AuctionServiceClient("BasicHttpBinding_IAuctionService");
            proxy.Open();
            ViewBag.CategoryId = new SelectList(proxy.GetAllCategories(), "Id", "Name");
            proxy.Close();
            return View();
        }

        // GET: Auction/Create
        public ActionResult WinAution()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var email = db.Users.Where(e => e.UserName == User.Identity.Name).FirstOrDefault().Email;
            var proxy = new AuctionServiceClient("BasicHttpBinding_IAuctionService");
            proxy.Open();
            var items = proxy.GetMyWonAuctionsHistory(email);
            proxy.Close();
            db.Dispose();
            return View(items);
        }

        // POST: Auction/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,BestBid,Description,Name,PhotoUrl,Price")] Auction auction)
        {
            if (ModelState.IsValid)
            {
                ApplicationDbContext db = new ApplicationDbContext();
                var email = db.Users.Where(e => e.UserName == User.Identity.Name).FirstOrDefault().Email;
                var proxy = new AuctionServiceClient("BasicHttpBinding_IAuctionService");
                proxy.Open();
                var cateId = int.Parse(Request["CategoryId"]);
                auction.CategoryId = cateId;
                auction.StartTime = DateTime.Now;
                auction.EndTime = DateTime.Now;
                auction.AutionStatus = AuctionStatus.New;
                proxy.AddNewAuction(email, auction);
                proxy.Close();
                return RedirectToAction("Index");
            }

            return View(auction);
        }

        [HttpPost]
        public ActionResult Start()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var email = db.Users.Where(e => e.UserName == User.Identity.Name).FirstOrDefault().Email;
            var startTime = DateTime.Parse(Request["StartTime"]);
            var endTime = DateTime.Parse(Request["EndTime"]);
            var id = int.Parse(Request["Id"]);
            var proxy = new AuctionServiceClient("BasicHttpBinding_IAuctionService");
            proxy.Open();
            proxy.StartAuction(email, id, startTime, endTime);
            proxy.Close();
            db.Dispose();
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
