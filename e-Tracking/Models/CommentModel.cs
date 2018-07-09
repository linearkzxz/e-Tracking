using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace e_Tracking.Models
{
    public class CommentModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int? ParentId { get; set; }
        public string PrNumber { get; set; }
        public string UpdateDate { get; set; }
        public string UserId { get; set; }
        public List<CommentModel> replyComments { get; set; }
    }
}