using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace NimapProject.Model
{
    public class nimap
    {
        [Key]
        public int ProductId { get; set; }
        public string? ProductName { get; set; }

        public int CategoryId { get; set; }

        public string? CategoryName { get; set; }
    }
}
