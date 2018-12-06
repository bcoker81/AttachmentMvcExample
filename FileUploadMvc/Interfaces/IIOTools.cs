using System.Web;
using FileUploadMvc.Models;

namespace FileUploadMvc.Interfaces
{
    public interface IIOTools
    {
        string Upload(HttpPostedFileBase file, ViewModel viewModel);
        DocumentRetrieval OpenFileAttachment(int attachmentId);
    }
}