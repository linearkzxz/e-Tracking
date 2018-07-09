using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace e_Tracking.Context
{
    public partial class ETrackingContext : DbContext
    {
        public ETrackingContext(): base("name=ETrackingContext") 
        {
        }
        public DbSet<Comment> Comments { get; set; }
    }

    //public class Comment
    //{
    //    public int CommentId { get; set; }
    //    public string Text { get; set; }
    //    public int? ParentId { get; set; }
    //    public int PrNumber { get; set; }
    //    public List<Comment> replyComments { get; set; }
    //}
}