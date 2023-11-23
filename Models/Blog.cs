using System.ComponentModel.DataAnnotations;

namespace OganiMVC.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ReplyCount { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ImageURL { get; set; }
        
    }
}
