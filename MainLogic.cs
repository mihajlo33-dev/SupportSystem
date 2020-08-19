using SupportSystem333.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Security.Claims;

namespace SupportSystem333.MainLogic
{
    public class MainLogic
    {
        SupportSystemEntities DB = null;
        public MainLogic()
        {
            DB = new SupportSystemEntities();


        }



        public void SnimiKomentar(string CommentText, int SuggestionID)
        {
            var noviKomentar = new Comment
            {
                CommentText = CommentText,

                SuggestionID = SuggestionID,

                UserID = 1,

                CommentDate = DateTime.Now,
                Username = HttpContext.Current.User.Identity.Name


            };

            DB.Comments.Add(noviKomentar);
            DB.SaveChanges();
        }


        public List<Comment> SviKomentari()
        {
            List<Comment> komentar = DB.Comments.ToList();
            return komentar;
        }

        public void SnimiReply(string CommentText, int CommentID)
        {
            var data = DB.Comments.FirstOrDefault(x => x.CommentID == CommentID);

            if (data != null)
            {
                data.CommentText = CommentText;

                DB.SaveChanges();
            }


            //var noviReply = new Comment
            //{
            //    CommentText = CommentText,

            //    SuggestionID = SuggestionID,

            //    UserID = 1,

            //    ParentId = ParentId,

            //    CommentDate = DateTime.Now
            //};

            //DB.Comments.Add(noviReply);
            //DB.SaveChanges();
        }

        public void Reply(string CommentText,int SuggestionID,int ParentId)
        {
            var noviReply = new Comment
            {
                CommentText = CommentText,

                ParentId= ParentId,

               


                SuggestionID = SuggestionID,

                UserID = 1,

                CommentDate = DateTime.Now,

                Username = HttpContext.Current.User.Identity.Name
            };

            DB.Comments.Add(noviReply);
            DB.SaveChanges();
        }


        public List<Comment> SviReply()
        {
            List<Comment> reply = DB.Comments.ToList();
            return reply;
        }

     




    }
}
