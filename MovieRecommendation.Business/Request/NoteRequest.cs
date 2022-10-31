using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendation.Business.Request
{
    public class NoteRequest
    {
        [Required]
        public int MovieId { get; set; }

        [Required]
        public string Note { get; set; }
    }
}