using System.ComponentModel;

namespace DevSpace_BusinessLayer.Infrastructure.Dto
{
    public class PostResourceDto
    {
        public string? FolderId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
    }
}