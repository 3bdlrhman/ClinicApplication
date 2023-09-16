using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClinicApplication.Models;
using ClinicApplication.Models.ViewModels;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace ClinicApplication.Controllers
{
    [Authorize(Roles = "Secretary,Admin")]
    public class SecretaryController : Controller
    {
        private readonly ClinicDbContext _context;

        public SecretaryController(ClinicDbContext context)
        {
            _context = context;
        }


        // GET: Secretary
        public async Task<IActionResult> Index()
        {
            // Eager Loading the Entity <Doctor>
            var doctorSchedules = _context.TbldoctorSchedules
                .Select(i => new NewAppointment
                {
                    Id=i.ScheduleId,
                    DoctorName = i.Doctor.DoctorName,
                    StartTime = (i.StartTime.Value.ToString(@"hh\:mm")),
                    EndTime = (i.EndTime.Value.ToString(@"hh\:mm")),
                    PatientName = i.PatientName,
                    PatientAge = i.PatientAge.Value, 
                    DayName = i.Date.Value.DayOfWeek.ToString(), 
                    Date = DateOnly.Parse(i.Date.ToString()).ToString()
                });

            return View(await doctorSchedules.ToListAsync());
        }



        // GET: Secretary/Create
        public IActionResult Create()
        {
            var docs = _context.Tbldoctors.ToList();

            ViewBag.DoctorNames = new SelectList(_context.Tbldoctors, "DoctorId", "DoctorName");

            var days = _context.WeekDays.ToList();
            ViewBag.DayOfWeekList = new SelectList(days, "Id", "Day");

            return View();
        }



        // POST: Secretary/Create
        [HttpPost]
        public async Task<IActionResult> Create(NewAppointment appointment)
        {
            if (ModelState.IsValid)
            {
                TimeOnly start = TimeOnly.Parse(appointment.StartTime);
                TimeOnly end = TimeOnly.Parse(appointment.EndTime);
                
                var newSchedule = new TbldoctorSchedule
                {
                    DoctorId = appointment.DoctorId,
                    DayOfWeek = (int)DateTime.Parse(appointment.Date).DayOfWeek,
                    StartTime = start.ToTimeSpan(),
                    EndTime = end.ToTimeSpan(),
                    PatientName = appointment.PatientName,
                    PatientAge = appointment.PatientAge,
                    Date = DateTime.Parse(appointment.Date.ToString())
                };

                await _context.TbldoctorSchedules.AddAsync(newSchedule);
                await _context.SaveChangesAsync();

                return Json("True");
            }

            return Json("False");
        }


        #region Helper AJAX methods

        public bool CheckDoctorTime(int doctorId, string startTime, string startDate)
        {

            var date = DateTime.Parse(startDate);
            var day = (int)DateTime.Parse(startDate).DayOfWeek;


            var doctorWorkingDays = _context.DoctorWorkDays
                .Where(s => s.DoctorId == doctorId)
                .Select(dd => dd.DayId).ToList();

            if (!doctorWorkingDays.Contains(day))
            {
                return false;
            }

            var isPM = startTime.Contains("PM"); 
            var time = TimeSpan.Parse(startTime);

            // get all the doctor schedules that date
            var allSchedules = _context.TbldoctorSchedules.Where(d => d.DoctorId == doctorId && d.Date == date).ToList();
            foreach (var item in allSchedules)
            {
                if (IsTimeInRange(time, item.StartTime.Value, item.EndTime.Value, isPM))
                {
                    return false;
                }
            }


            return true;
        }

        public ContentResult CheckDoctorWorkDay(int doctorId, string startDate)
        {
            var date = DateTime.Parse(startDate);
            var day = (int)DateTime.Parse(startDate).DayOfWeek;


            var doctorWorkingDays = _context.DoctorWorkDays
                .Where(s => s.DoctorId == doctorId)
                .Select(dd => dd.DayId).ToList();

            if (!doctorWorkingDays.Contains(day))
            {
                return Content($"{date.DayOfWeek.ToString()} is not in the working days for doc " +
                    $"{_context.Tbldoctors.Find(doctorId).DoctorName}");
            }

            return Content("True");
        }

        // Function to check if time is within a specified range
        bool IsTimeInRange(TimeSpan timeToCheck, TimeSpan startTime, TimeSpan endTime, bool isPM)
        {
            if (isPM)
            {
                // If it's PM, add 12 hours to the end time for comparison
                endTime = endTime.Add(new TimeSpan(12, 0, 0));
            }

            return timeToCheck >= startTime && timeToCheck <= endTime;
        }
        #endregion


        #region Delete Action

        // GET: Secretary/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TbldoctorSchedules == null)
            {
                return NotFound();
            }

            var tbldoctorSchedule = await _context.TbldoctorSchedules
                .Include(t => t.Doctor)
                .FirstOrDefaultAsync(m => m.ScheduleId == id);
            if (tbldoctorSchedule == null)
            {
                return NotFound();
            }

            return View(tbldoctorSchedule);
        }

        // POST: Secretary/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TbldoctorSchedules == null)
            {
                return Problem("Entity set 'ClinicDbContext.TbldoctorSchedules'  is null.");
            }
            var tbldoctorSchedule = await _context.TbldoctorSchedules.FindAsync(id);
            if (tbldoctorSchedule != null)
            {
                _context.TbldoctorSchedules.Remove(tbldoctorSchedule);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        #endregion
    }
}
