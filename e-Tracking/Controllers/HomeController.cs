using System;
using System.Web;
using System.Web.Mvc;
using e_Tracking.Models;
using System.Collections.Generic;
using e_Tracking.Bussiness;
using System.Linq;
using System.Globalization;

namespace e_Tracking.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            CommentAppService commentAppService = new CommentAppService();
            var items = commentAppService.FindByPrNumber("1100069792");

            var commentItems = items.Where(x => x.ParentId == null);
            var replyItems = items.Where(x => x.ParentId != null);
            var commentModels = new List<CommentModel>();

            foreach (var i in commentItems)
            {
                var comment = ConvertToViewModel(i);
                comment.replyComments = new List<CommentModel>();
                var replies = replyItems.Where(x => x.ParentId == i.Id).ToList();
                foreach (var j in replies)
                {
                    var reply = ConvertToViewModel(j);
                    comment.replyComments.Add(reply);
                }
                commentModels.Add(comment);
            }

            return View(commentModels);
        }

        public ActionResult AnotherLink()
        {
            return View("Index");
        }

        [HttpPost]
        public ActionResult AddComment(CommentModel item)
        {
            var comment = new Comment();
            comment.Text = item.Text;
            comment.ParentId = item.ParentId;
            comment.PrNumber = item.PrNumber;
            comment.UserId = "123-456-789";

            CommentAppService commentAppService = new CommentAppService();
            var a = commentAppService.Add(comment);

            return Json("Success", JsonRequestBehavior.AllowGet);
        }

        public CommentModel ConvertToViewModel(Comment model)
        {
            var vm = new CommentModel();
            vm.Id = model.Id;
            vm.Text = model.Text;
            vm.ParentId = model.ParentId;
            vm.PrNumber = model.PrNumber;
            vm.UserId = model.UserId;
            vm.UpdateDate = model.UpdateDate.ToString("dd-MMM-yyyy HH:mm");
            return vm;
        }
    }
}
