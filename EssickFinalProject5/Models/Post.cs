using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EssickFinalProject5.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Contents { get; set; }
        public string Image { get; set; }

        public DateTime Create { get; set; } = DateTime.Now;
        public List<Main> MainComments { get; set; }
    }
}
