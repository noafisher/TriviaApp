using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaApp.Models
{
    public class Rank
    {
        public string RankName { get; set; } = null!;
        public int RankId { get; set; }
        public Rank()
        {
            
        }
    }
}
