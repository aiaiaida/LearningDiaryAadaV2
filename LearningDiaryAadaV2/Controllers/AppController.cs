using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LearningDiaryAadaV2.Data;
using LearningDiaryAadaV2.Models;

namespace LearningDiaryAadaV2.Controllers
{
    public class AppController : Controller
    {
        private readonly LearningDiaryAadaV2Context _context;

        public AppController(LearningDiaryAadaV2Context context)
        {
            _context = context;
        }
        public async Task<IActionResult> GetStarted()
        {
            return View(await _context.Topic.ToListAsync());
        }
        public async Task<IActionResult> TaskView()
        {
            return View(await _context.TaskInTopic.ToListAsync());
        }
        public async Task<IActionResult> NoteView()
        {
            return View(await _context.Note.ToListAsync());
        }
    }
}
