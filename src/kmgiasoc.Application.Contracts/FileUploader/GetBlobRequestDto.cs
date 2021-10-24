using System.ComponentModel.DataAnnotations;

namespace kmgiasoc.FileUploader
{
    public class GetBlobRequestDto
    {
        [Required]
        public string Name { get; set; }
    }
}
