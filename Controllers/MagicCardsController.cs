using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TCGPlayerKevinMohan.Models;
using TCGPlayerKevinMohan.Repositories;

namespace TCGPlayerKevinMohan.Controllers
{
    public class MagicCardsController : Controller
    {
        private MagicCardContext db = new MagicCardContext();
        private readonly MagicCardsRepository _magicCardRepository;

        public MagicCardsController()
        {
            _magicCardRepository = new MagicCardsRepository();
        }

        public ActionResult Index()
        {
            try
            {
                return View(db.MagicCards.ToList());
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        public ActionResult GetCardsInitialSearch(string inputSearchText)
        {
            return PartialView("CardInitialSearch", _magicCardRepository.GetCardsInitialSearchStoredProc(inputSearchText));      
        }
        
        public ActionResult Details(int? id)
        {
            var model = new MagicCardDetail();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MagicCard magicCard = db.MagicCards.Single(o => o.CardId == id);
            if (magicCard == null)
            {
                return HttpNotFound();
            }

            model.AccessPath = magicCard.AccessPath;
            model.CardId = magicCard.CardId;
            model.CardName = magicCard.CardName;
            model.CardText = magicCard.CardText;
            model.Number = magicCard.Number;
            model.Quantity = magicCard.Quantity;
            model.Price = magicCard.Price;
            model.SetInfo = _magicCardRepository.GetSetInfoBySetId(magicCard.SetId);
            model.RarityInfo = _magicCardRepository.GetRarityInfoByRarityId(magicCard.RarityId);

            return PartialView(model);
        }
        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CardId,CardName,CardText,Number,SetId,RarityId,Price,Quantity,AccessPath")] MagicCard magicCard, HttpPostedFileBase file)
        {
            if (ModelState.IsValid && file != null)
            {
                var filename = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Images/"), filename);
                file.SaveAs(path);
                magicCard.AccessPath = @"\App_Data\Images\" + filename;
                db.MagicCards.Add(magicCard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(magicCard);
        }
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MagicCard magicCard = db.MagicCards.Find(id);
            if (magicCard == null)
            {
                return HttpNotFound();
            }
            return View(magicCard);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CardId,CardName,CardText,Number,SetId,RarityId,Price,Quantity,AccessPath")] MagicCard magicCard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(magicCard).State = EntityState.Modified;
                db.SaveChanges();
                _magicCardRepository.LogDBChange(magicCard);
                return RedirectToAction("Index");
            }
            return View(magicCard);
        }
        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
