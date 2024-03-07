using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaApp.Models
{
    public class Question
    {
        
        public SubjectQuestion Subject { get; set; } = null!;

        public string Text { get; set; } = null!;

        public int QuestionId { get; set; }

        public string Ranswer { get; set; } = null!;

        public string Wanswer1 { get; set; } = null!;

        public string Wanswer2 { get; set; } = null!;

        public string Wanswer3 { get; set; } = null!;

        public string CreatedBy { get; set; } = null!;

        public StatusQuestion Status { get; set; }


    }
}
