using FileUploadMvc.Interfaces;
using FileUploadMvc.Models;
using FileUploadMvc.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FileUploadMvc.Controllers
{
    public class GrantsController : Controller
    {
        private static GmsDbContext _context = new GmsDbContext();
        private static ViewModel _viewModel;
        private int counter =1;
        private static IIOTools _util = new IOTools();

        // GET: Grants
        public ActionResult Index()
        {
            _viewModel = new ViewModel();

            _viewModel.Grants = _context.Grants.ToList();
            foreach (var item in _viewModel.Grants)
            {
                item.AttachmentCount = _context.Attachments.Where(p => p.FK_Id == item.Id).Count();
            }
            return View("Index", _viewModel);
        }

        public ActionResult NewGrant()
        {
            return View("NewGrant");
        }

        public ActionResult SaveGrant(ViewModel model)
        {
            _context.Grants.Add(model.Grant);
            _context.SaveChanges();


            return RedirectToAction("Index");
        }

        public ActionResult SelectAttachment(int? id)
        {
            ViewModel model = new ViewModel();
            model.Grant.Id = (int)id;
            model.Grant = _context.Grants.First(p => p.Id == id);
            ViewBag.FileInfo = string.Empty;
            return View("_Attachments", model);
        }

        [HttpPost]
        public virtual ActionResult Upload(HttpPostedFileBase file, ViewModel viewModel)
        {
            _util.Upload(file, viewModel);
            ViewBag.FileInfo = "File uploaded successfully.";
            return RedirectToAction("GetGrantDetails", new { viewModel.Grant.Id });
        }

        public ActionResult GetGrantDetails(int id)
        {
            ViewModel model = new ViewModel();

            model.Grant = _context.Grants.Where(p => p.Id == id).FirstOrDefault();
            model.Attachments = _context.Attachments.Where(p => p.FK_Id == id).ToList();

            return View("GetGrantDetails", model);
        }

        public ActionResult OpenAttachment(int attachmentId)
        {
            var attachmentMeta = _context.Attachments.Where(p => p.FK_Id == attachmentId);
            DocumentRetrieval attachment = _util.OpenFileAttachment(attachmentId);

            using (Stream file = System.IO.File.OpenWrite($"c:\\temp\\BPD01Content\\{attachment.FileName}"))
            {
                file.Write(attachment.DocData, 0, attachment.DocData.Length);
            }

            return RedirectToAction("Index");
        }
    }
}