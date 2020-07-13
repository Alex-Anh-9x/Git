using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Threading.Tasks;

namespace Pada.Models
{
    public partial class PendingPhotoRequest
    {
        [Key]
        public int TransactionId { get; set; }
        //[Index(Unique = true)]
        //[MaxLength(255)] // for code-first implementations
        public string Email { get; set; }
        public int Type { get; set; }
        public string OldPhotoPath { get; set; }
        public string NewPhotoPath { get; set; }
        public int? AcceptedVote { get; set; }
        public int? RejectedVote { get; set; }
        public int? VoteRequired { get; set; }
        public string FullPhotoPath { get; set; }
        public string FacePhotoPath { get; set; }
        public string AnyPhotoPath { get; set; }
        public int? PendingVote { get; set; }

        [NotMapped]
        [DisplayName("Upload Full Image File")]
        public IFormFile FullImageFile { get; set; }
        [NotMapped]
        [DisplayName("Upload Face Image File")]
        public IFormFile FaceImageFile { get; set; }
        [NotMapped]
        [DisplayName("Upload Any Image File")]
        public IFormFile AnyImageFile { get; set; }
        public async Task<string> UploadPhoto(IFormFile ImageFile, IWebHostEnvironment _hostEnvironment)
        {
            string wwwRootPath = _hostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(ImageFile.FileName);
            string extension = Path.GetExtension(ImageFile.FileName);
            string imageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            string path = Path.Combine(wwwRootPath + "/image/", fileName);
            using (var filestream = new FileStream(path, FileMode.Create))
            {
                ImageFile.CopyTo(filestream);
            }
            string storageConnectionString = "DefaultEndpointsProtocol=https;AccountName=chinhlanhuvaycf7e180a308;AccountKey=ufsUzB/+lb4VQX2QDXECQO9ZRVWaxc2G6nKEQD1Bo40Px7n9Ajs5pJHWB0nmKfVFZnvaFaacsh/Trmtrci+U+w==;EndpointSuffix=core.windows.net";
            CloudStorageAccount storageacc = CloudStorageAccount.Parse(storageConnectionString);
            CloudBlobClient blobClient = storageacc.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference("vhds");
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(imageName);
            await blockBlob.UploadFromFileAsync(path);
            return blockBlob.Uri.AbsoluteUri;
        }
    }

}
