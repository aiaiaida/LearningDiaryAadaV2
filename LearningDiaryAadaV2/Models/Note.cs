using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

#nullable disable

namespace LearningDiaryAadaV2.Models
{
    public partial class Note
    {
        public int Id { get; set; }
        [Display(Name = "Topic ID")]
        [DisplayFormat(NullDisplayText = "Not set")]
        public int? TopicId { get; set; }
        [Display(Name = "Task ID")]
        [DisplayFormat(NullDisplayText = "Not set")]
        public int? TaskId { get; set; }
        [Display(Name = "Note")]
        [DisplayFormat(NullDisplayText = "Not set")]
        public string Note1 { get; set; }

        public virtual TaskInTopic Task { get; set; }
        public virtual Topic Topic { get; set; }
    }
}

