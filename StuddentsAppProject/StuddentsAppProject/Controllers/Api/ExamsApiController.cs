using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StuddentsAppProject.Data;
using StuddentsAppProject.Models;
using StuddentsAppProject.Models.DTOs;

namespace StuddentsAppProject.Controllers.Api
{
    [Route("api/exam")]
    [ApiController]
    public class ExamsApiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ExamsApiController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/exam
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Exam>>> GetExams()
        {
            // Include Student and Subject for detailed information
            return await _context.Exams
                .Include(e => e.Student)
                .Include(e => e.Subject)
                .ToListAsync();
        }

        // GET: api/exam/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Exam>> GetExam(int id)
        {
            var exam = await _context.Exams
                .Include(e => e.Student)
                .Include(e => e.Subject)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (exam == null)
            {
                return NotFound();
            }

            return exam;
        }

        // POST: api/exam
        [HttpPost]
        public async Task<ActionResult<Exam>> CreateExam(CreateExamDto examDto)
        {
            // Check if Student and Subject exist
            if (!_context.Students.Any(s => s.Id == examDto.StudentId))
            {
                return BadRequest("Invalid Student ID.");
            }

            if (!_context.Subjects.Any(s => s.Id == examDto.SubjectId))
            {
                return BadRequest("Invalid Subject ID.");
            }

            // Check for uniqueness (StudentId + SubjectId)
            /*
            if (_context.Exams.Any(e => e.StudentId == examDto.StudentId && e.SubjectId == examDto.SubjectId))
            {
                return BadRequest("This student already has an exam for this subject.");
            }
            */

            var exam = new Exam
            {
                StudentId = examDto.StudentId,
                SubjectId = examDto.SubjectId,
                DateOfExam = examDto.DateOfExam,
                ExamMark = examDto.ExamMark,
            };

            _context.Exams.Add(exam);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetExam), new { id = exam.Id }, exam);
        }

        // PUT: api/exam/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExam(int id, UpdateExamDto examDto)
        {
            if (id != examDto.Id)
            {
                return BadRequest();
            }

            // Validate Student and Subject IDs
            if (!_context.Students.Any(s => s.Id == examDto.StudentId))
            {
                return BadRequest("Invalid Student ID.");
            }

            if (!_context.Subjects.Any(s => s.Id == examDto.SubjectId))
            {
                return BadRequest("Invalid Subject ID.");
            }

            var exam = new Exam
            {
                Id = examDto.Id,
                StudentId = examDto.StudentId,
                SubjectId = examDto.SubjectId,
                DateOfExam = examDto.DateOfExam,
                ExamMark = examDto.ExamMark,
            };

            // Set entity as modified.
            _context.Entry(exam).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Exams.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/exam/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExam(int id)
        {
            var exam = await _context.Exams.FindAsync(id);

            if (exam == null)
            {
                return NotFound();
            }

            _context.Exams.Remove(exam);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
