using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WebSite.Models;

namespace WebSite.Controllers
{
    public class ImagePostsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ImagePosts
        public ActionResult Index()
        {
            return View(db.ImagePosts.ToList());
        }

        // GET: ImagePosts/Details/5
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImagePost imagePost = db.ImagePosts.Find(id);
            if (imagePost == null)
            {
                return HttpNotFound();
            }
            return View(imagePost);
        }

        // GET: ImagePosts/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: ImagePosts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Description")] ImagePost imagePost/*, HttpPostedFileBase file*/)
        {
            //if (file.ContentLength > 0)
            //{
            //    var fileName = Path.GetFileName(file.FileName);
            //    var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
            //    file.SaveAs(path);
            //    imagePost.Image = file;
            //}

            var image = WebImage.GetImageFromRequest();
            var filename = Path.GetFileName(image.FileName);
            var path = Path.Combine(Server.MapPath("~/Images"), filename);
            image.Save(path);
            imagePost.ImageUrl = Url.Content(Path.Combine("~/Images", filename));
            path = Url.Content(Path.Combine("~/Images", filename));

            if (ModelState.IsValid)
            {
                db.ImagePosts.Add(imagePost);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(imagePost);
        }

        //[HttpPost]
        //public ActionResult Create(HttpPostedFileBase file)
        //{
        //    if (file.ContentLength > 0)
        //    {
        //        var fileName = Path.GetFileName(file.FileName);
        //        var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
        //        file.SaveAs(path);
        //    }

        //    return RedirectToAction("Index");
        //}

        // GET: ImagePosts/Edit/5
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImagePost imagePost = db.ImagePosts.Find(id);
            if (imagePost == null)
            {
                return HttpNotFound();
            }
            return View(imagePost);
        }

        // POST: ImagePosts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Description")] ImagePost imagePost)
        {
            if (ModelState.IsValid)
            {
                db.Entry(imagePost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(imagePost);
        }

        // GET: ImagePosts/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImagePost imagePost = db.ImagePosts.Find(id);
            if (imagePost == null)
            {
                return HttpNotFound();
            }
            return View(imagePost);
        }

        // POST: ImagePosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ImagePost imagePost = db.ImagePosts.Find(id);
            db.ImagePosts.Remove(imagePost);
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
