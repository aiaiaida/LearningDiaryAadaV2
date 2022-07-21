using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LearningDiaryAadaV2.Models;

namespace LearningDiaryAadaV2.Data
{
    public class LearningDiaryAadaV2Context : DbContext
    {
        public LearningDiaryAadaV2Context (DbContextOptions<LearningDiaryAadaV2Context> options)
            : base(options)
        {
        }

        public DbSet<LearningDiaryAadaV2.Models.Topic> Topic { get; set; }

        public DbSet<LearningDiaryAadaV2.Models.TaskInTopic> TaskInTopic { get; set; }

        public DbSet<LearningDiaryAadaV2.Models.Note> Note { get; set; }
    }
}
