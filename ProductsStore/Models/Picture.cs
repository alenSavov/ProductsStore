using System.ComponentModel.DataAnnotations;

namespace ProductsStore.Models
{
    public class Picture
    {
        public string Id { get; set; }

        [Required]
        public string Url { get; set; }

        [Required]
        public string ItemId { get; set; }

        public Item Item { get; set; }
    }
}
