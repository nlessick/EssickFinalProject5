using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EssickFinalProject5.ViewModels
{
    public class ResponseViewModel
    {
        [Required]
        public int PostId { get; set; }
        [Required]
        public int MainId { get; set; }
        [Required]
        public string Content { get; set; }
    }
}
