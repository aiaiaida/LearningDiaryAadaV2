using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


#nullable disable

namespace LearningDiaryAadaV2.Models
{
    public partial class Topic
    {

        public int Id { get; set; }
        [Display(Name = "Title")]
        [DisplayFormat(NullDisplayText = "Null")]
        public string Title { get; set; }
        [Display(Name = "Description")]
        [DisplayFormat(NullDisplayText = "Not set")]
        public string Description { get; set; }
        [Display(Name = "Estimated master time")]
        [DisplayFormat(NullDisplayText = "Not set")]
        public int? EstimatedTimeToMaster { get; set; }
        [Display(Name = "Time spent")]
        [DisplayFormat(NullDisplayText = "Not set")]
        public int? TimeSpent { get; set; }
        [Display(Name = "Source")]
        [DisplayFormat(NullDisplayText = "Not set")]
        public string Source { get; set; }
        [Display(Name = "Start learning date")]
        [DisplayFormat(NullDisplayText = "Not set")]
        public DateTime? StartLearningDate { get; set; }
        [Display(Name = "In progress")]
        [DisplayFormat(NullDisplayText = "Not set")]
        public bool? InProgress { get; set; }
        [Display(Name = "Completion date")]
        [DisplayFormat(NullDisplayText = "Not set")]
        public DateTime? CompletionDate { get; set; }

        public virtual ICollection<Note> Notes { get; set; }
        public virtual ICollection<TaskInTopic> TaskInTopics { get; set; }
    }
}
