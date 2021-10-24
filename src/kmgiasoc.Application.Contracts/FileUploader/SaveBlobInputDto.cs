using System.ComponentModel.DataAnnotations;

namespace kmgiasoc.FileUploader
{
    public class SaveBlobInputDto
    {
        public byte[] Content { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
