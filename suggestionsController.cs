using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SupportSystem333.Models;

namespace SupportSystem333.Controllers
{
    public class suggestionsController : Controller
    {
        private SupportSystemEntities db = new SupportSystemEntities();

        // GET: suggestions

        public ActionResult Closed()
        {
            var suggestions = db.suggestions.Include(s => s.section).Include(s => s.severity).Include(s => s.status).Where(u => u.ID_status == 3);
            return View(suggestions.ToList());


        }
        public ActionResult Index()
        {
            var suggestions = db.suggestions.Include(s => s.section).Include(s => s.severity).Include(s => s.status);
            return View(suggestions.ToList());
        }

        // GET: suggestions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            suggestion suggestion = db.suggestions.Find(id);
            if (suggestion == null)
            {
                return HttpNotFound();
            }
            return View(suggestion);
        }

        // GET: suggestions/Create
        public ActionResult Create()
        {
            ViewBag.ID_section = new SelectList(db.sections, "ID_section", "sectionname");
            ViewBag.ID_severity = new SelectList(db.severities, "ID_severity", "name_severity");
            ViewBag.ID_status = new SelectList(db.status, "ID_status", "name");
            return View();
        }

        // POST: suggestions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_suggestion,createdby,createdon,ID_status,category,ID_section,ID_severity,title,priority,acceptedon,duedate,resolvedon,ticektno")] suggestion suggestion)
        {
            if (ModelState.IsValid)
            {
                db.suggestions.Add(suggestion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_section = new SelectList(db.sections, "ID_section", "sectionname", suggestion.ID_section);
            ViewBag.ID_severity = new SelectList(db.severities, "ID_severity", "name_severity", suggestion.ID_severity);
            ViewBag.ID_status = new SelectList(db.status, "ID_status", "name", suggestion.ID_status);
            return View(suggestion);
        }

        // GET: suggestions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            suggestion suggestion = db.suggestions.Find(id);
            if (suggestion == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_section = new SelectList(db.sections, "ID_section", "sectionname", suggestion.ID_section);
            ViewBag.ID_severity = new SelectList(db.severities, "ID_severity", "name_severity", suggestion.ID_severity);
            ViewBag.ID_status = new SelectList(db.status, "ID_status", "name", suggestion.ID_status);
            return View(suggestion);
        }

        // POST: suggestions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_suggestion,createdby,createdon,ID_status,category,ID_section,ID_severity,title,priority,acceptedon,duedate,resolvedon,ticketno,steps, resolve")] suggestion suggestion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(suggestion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_section = new SelectList(db.sections, "ID_section", "sectionname", suggestion.ID_section);
            ViewBag.ID_severity = new SelectList(db.severities, "ID_severity", "name_severity", suggestion.ID_severity);
            ViewBag.ID_status = new SelectList(db.status, "ID_status", "name", suggestion.ID_status);
            return View(suggestion);
        }

        // GET: suggestions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            suggestion suggestion = db.suggestions.Find(id);
            if (suggestion == null)
            {
                return HttpNotFound();
            }
            return View(suggestion);
        }

        // POST: suggestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            suggestion suggestion = db.suggestions.Find(id);
            db.suggestions.Remove(suggestion);
            db.SaveChanges();
            return RedirectToAction("Index");
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
