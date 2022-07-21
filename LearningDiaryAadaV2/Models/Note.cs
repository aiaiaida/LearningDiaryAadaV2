using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#nullable disable

namespace LearningDiaryAadaV2.Models
{
    public partial class Note
    {
        public int Id { get; set; }
        public int? TopicId { get; set; }
        public int? TaskId { get; set; }
        public string Note1 { get; set; }

        public virtual TaskInTopic Task { get; set; }
        public virtual Topic Topic { get; set; }
    }
}

