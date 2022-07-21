using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LearningDiaryAadaV2.Data;
using LearningDiaryAadaV2.Models;

namespace LearningDiaryAadaV2.Controllers
{
    public class TaskInTopicsController : Controller
    {
        private readonly LearningDiaryAadaV2Context _context;

        public TaskInTopicsController(LearningDiaryAadaV2Context context)
        {
            _context = context;
        }

        // GET: TaskInTopics
        public async Task<IActionResult> Index()
        {
            var learningDiaryAadaV2Context = _context.TaskInTopic.Include(t => t.Topic);
            return View(await learningDiaryAadaV2Context.ToListAsync());
        }

        // GET: TaskInTopics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskInTopic = await _context.TaskInTopic
                .Include(t => t.Topic)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taskInTopic == null)
            {
                return NotFound();
            }

            return View(taskInTopic);
        }

        // GET: TaskInTopics/Create
        public IActionResult Create()
        {
            ViewData["TopicId"] = new SelectList(_context.Topic, "Id", "Id");
            return View();
        }

        // POST: TaskInTopics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TopicId,Title,Description,Deadline,Priority,Done")] TaskInTopic taskInTopic)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taskInTopic);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TopicId"] = new SelectList(_context.Topic, "Id", "Id", taskInTopic.TopicId);
            return View(taskInTopic);
        }

        // GET: TaskInTopics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskInTopic = await _context.TaskInTopic.FindAsync(id);
            if (taskInTopic == null)
            {
                return NotFound();
            }
            ViewData["TopicId"] = new SelectList(_context.Topic, "Id", "Id", taskInTopic.TopicId);
            return View(taskInTopic);
        }

        // POST: TaskInTopics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TopicId,Title,Description,Deadline,Priority,Done")] TaskInTopic taskInTopic)
        {
            if (id != taskInTopic.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taskInTopic);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskInTopicExists(taskInTopic.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("TaskView","App");
            }
            ViewData["TopicId"] = new SelectList(_context.Topic, "Id", "Id", taskInTopic.TopicId);
            return View(taskInTopic);
        }

        // GET: TaskInTopics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskInTopic = await _context.TaskInTopic
                .Include(t => t.Topic)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taskInTopic == null)
            {
                return NotFound();
            }

            return View(taskInTopic);
        }

        // POST: TaskInTopics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taskInTopic = await _context.TaskInTopic.FindAsync(id);
            _context.TaskInTopic.Remove(taskInTopic);
            await _context.SaveChangesAsync();
            return RedirectToAction("TaskView", "App");
        }

        private bool TaskInTopicExists(int id)
        {
            return _context.TaskInTopic.Any(e => e.Id == id);
        }
    }
}
