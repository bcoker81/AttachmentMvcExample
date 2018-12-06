using FileUploadMvc.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace FileUploadMvc.Controllers
{
    public class HomeController : Controller
    {
        static int counter = 1;
        //ButtNuggetEntities _entities = new ButtNuggetEntities();
        public ActionResult Index()
        {
            ViewModel model = new ViewModel();
           // model.Files = _entities.Files.ToList();
            return View("Index", model);
        }

        public ActionResult LoadRecord(int id)
        {
           // var result = _entities.Files.First(p => p.Id == id);

            //var fileText = System.IO.File.ReadAllText(result.FileData);

          //  byte[] imageBytes = Convert.FromBase64String(fileText);
            //System.Diagnostics.Process.Start(imageBytes.ToString());

            // Convert Base64 String to byte[]
          //  MemoryStream ms = new MemoryStream(imageBytes, 0,
           //   imageBytes.Length);

            // Convert byte[] to Image
          //  ms.Write(imageBytes, 0, imageBytes.Length);
           // BinaryWriter fuckYou = new BinaryWriter(ms, System.Text.Encoding.Unicode, true);
          //  fuckYou.Write(true);
            //Image image = Image.FromStream(ms, false, false);




            //FileStream fstrm = new FileStream(result.FileData, FileMode.CreateNew, FileAccess.Write);
            //BinaryWriter writer = new BinaryWriter(fstrm);
            //writer.Write(imageBytes);
            //writer.Close();
            //fstrm.Close();




            return View();
        }

        [HttpPost]
        public virtual ActionResult Upload(HttpPostedFileBase file)
        {
            string theFileName = (file.FileName);
            byte[] thePictureAsBytes = new byte[file.ContentLength];
            BinaryReader theReader = new BinaryReader(file.InputStream);

            thePictureAsBytes = theReader.ReadBytes(file.ContentLength);

            string base64Data = Convert.ToBase64String(thePictureAsBytes);

            var filePath = @"C:/temp/SomeFile.asses" + counter++;

            //FileStream fstrm = new FileStream(filePath, FileMode.CreateNew, FileAccess.Write);
            System.IO.File.WriteAllText(filePath, base64Data);
            //System.IO.File.WriteAllBytes(filePath, base64Data);
            
            //writer.Write(base64Data);

           // _entities.Files.Add(new Models.File { CreateDate = DateTime.Now, FileData = filePath, FileName = "KickassBunny.stuff" });
          //  _entities.SaveChanges();

            theReader.Dispose();
           
            return RedirectToAction("Index");
        }

        public virtual ActionResult Download(int id)
        {
           // var result = _entities.Files.First(p => p.Id == id);

          //  byte[] imageBytes = Convert.FromBase64String(result.FileData);
          //  FileStream fstrm = new FileStream(@"C:\temp\winnt_copy.doc", FileMode.CreateNew, FileAccess.Write);
         //   BinaryWriter writer = new BinaryWriter(fstrm);
         //   writer.Write(imageBytes);
         //   writer.Close();
         //   fstrm.Close();

            return RedirectToAction("Index");
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
    }
}