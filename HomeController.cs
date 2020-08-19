
using SupportSystem333.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SupportSystem333.Controllers
{
    public class HomeController : Controller
    {
        MainLogic.MainLogic Logic = null;

        

     


        public HomeController()
        {

            Logic = new MainLogic.MainLogic();

        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        


        [HttpPost]
        public JsonResult SnimiKomentar(string CommentText,int SuggestionID)
        {

            Logic.SnimiKomentar(CommentText,SuggestionID);

            return Json("OK", JsonRequestBehavior.AllowGet);

        }

        public JsonResult SviKomentari(int suggestionId)
        {
            try
            {
                SupportSystemEntities DB = new SupportSystemEntities();

                var komentar = DB.Comments.Where(x => x.SuggestionID == suggestionId && x.ParentId == null).Select(s => new { s.CommentText, s.CommentDate, s.UserID, s.CommentID,s.Username }).ToArray();
                
                return Json(komentar, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex, JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult SnimiReply(string CommentText, int CommentID)
        {

            Logic.SnimiReply(CommentText, CommentID);

            return Json("OK", JsonRequestBehavior.AllowGet);

        }

        public JsonResult Reply(string CommentText,int SuggestionID,int ParentId)
        {

            Logic.Reply(CommentText,SuggestionID,ParentId);

            return Json("OK", JsonRequestBehavior.AllowGet);

        }

        public JsonResult SviReply(int suggestionId)
        {
            try
            {
                SupportSystemEntities DB = new SupportSystemEntities();

                var reply = DB.Comments.Where(x => x.SuggestionID == suggestionId && x.ParentId != null).Select(s => new { s.CommentText, s.CommentDate, s.UserID, s.CommentID,s.ParentId,s.Username}).ToArray();

                return Json(reply, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex, JsonRequestBehavior.AllowGet);
            }

        }


    }
}