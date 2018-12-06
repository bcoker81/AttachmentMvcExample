using FileUploadMvc.Interfaces;
using FileUploadMvc.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace FileUploadMvc.Utilities
{
    public class IOTools : IIOTools
    {
        private static string _basePath = @"C:/temp/BPD01Content/";
        private int counter;
        private static GmsDbContext _context = new GmsDbContext();


        public string Upload(HttpPostedFileBase file, ViewModel viewModel)
        {
            string success = string.Empty;

            try
            {
                string theFileName = (file.FileName);
                byte[] thePictureAsBytes = new byte[file.ContentLength];
                BinaryReader theReader = new BinaryReader(file.InputStream);

                thePictureAsBytes = theReader.ReadBytes(file.ContentLength);

                string base64Data = Convert.ToBase64String(thePictureAsBytes);

                _context.Attachments.Add(new AttachmentsModel { FK_Id = viewModel.Grant.Id, Uri = "it's in the document table", FileType = file.ContentType, UploadDate = DateTime.Now, FileName = file.FileName });
                _context.Documents.Add(new DocumentModel { FK_Attachment_Id = viewModel.Attachment.Id, AddedDate = DateTime.Now, DocumentData = base64Data });

                _context.SaveChanges();
                theReader.Dispose();
                success = "Saved!";
            }
            catch (Exception)
            {
                success = "YOU GOTTA EXCEPTION MUTHA FUCKA!";
            }

            return success;
        }

        public bool CheckIfCaseJacketExists(string grantNumber)
        {
            bool exists = false;
            var path = $"{_basePath}{grantNumber}";
            if (grantNumber != null)
            {
                if (File.Exists(path))
                {
                    exists = true;
                }
            }
            else
            {
                exists = false;
            }

            return exists;
        }

        public void CreateDirectory(string grantNumber)
        {
            Directory.CreateDirectory($"{_basePath}{grantNumber}");
        }

        public bool DoesFileExist(string caseJacket, string filename)
        {
            bool result = false;

            if (File.Exists(caseJacket + filename))
            {
                result = true;
            }
            else { result = false; }
            return result;
        }

        public DocumentRetrieval OpenFileAttachment(int attachmentId)
        {
            DocumentRetrieval doc = new DocumentRetrieval();
            DocumentModel document = _context.Documents.Where(p => p.FK_Attachment_Id == attachmentId).Single();
            AttachmentsModel attachment = _context.Attachments.First(p => p.Id == attachmentId);
            doc.DocData = Convert.FromBase64String(document.DocumentData);
            doc.DocType = attachment.FileType;
            doc.FileName = attachment.FileName;
            return doc;
        }
    }
}