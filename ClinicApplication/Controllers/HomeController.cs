using System.Diagnostics;

using ClinicApplication.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ClinicDbContext _context;


        public HomeController(ILogger<HomeController> logger, ClinicDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Dashboard()
        {
            var patientCounts = _context.TbldoctorSchedules
                            .GroupBy(ds => ds.DoctorId)
                            .Select(group => new { DoctorName = group.First().Doctor.DoctorName, PatientCount = group.Count() })
                            .ToList();

            List<DoctorPatientViewModel> viewModel = patientCounts.Select(pc => new DoctorPatientViewModel
            {
                DoctorName = pc.DoctorName,
                PatientCount = pc.PatientCount
            }).ToList();

            return View(viewModel);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    public class DoctorPatientViewModel
    {
        public string DoctorName { get; set; }
        public int PatientCount { get; set; }
    }

}