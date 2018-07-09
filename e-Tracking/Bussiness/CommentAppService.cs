using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using e_Tracking.Context;

namespace e_Tracking.Bussiness
{
    public class CommentAppService
    {
        public List<Comment> Add(Comment comment)
        {
            try
            {
                using (var db = new ETrackingContext())
                {
                    comment.UpdateDate = DateTime.Now;
                    db.Comments.Add(comment);
                    db.SaveChanges();

                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Comment> FindByPrNumber(string prNumber)
        {
            try
            {
                using (var db = new ETrackingContext())
                {
                    var items = db.Comments.Where(i => i.PrNumber == prNumber).ToList();

                    return items;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}