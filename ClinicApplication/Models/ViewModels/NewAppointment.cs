using System.ComponentModel.DataAnnotations;

namespace ClinicApplication.Models.ViewModels
{
    public class NewAppointment
    {
        public int? Id { get; set; }

        [Display(Name = "Doctor")]
        public string DoctorName { get; set; }
        public int DoctorId { get; set; }
        
        [Display(Name = "Start Time")]
        public string StartTime { get; set; }
        
        [Display(Name = "End Time")]
        public string EndTime { get; set; }
        
        [Required]
        public int DayId { get; set; }

        [Display(Name = "Day")]
        public string DayName { get; set; }
        public string Date { get; set; }


        [Required]
        [Display(Name = "Patient")]
        public string PatientName { get; set; }

        [Required]
        [Display(Name = "Patient Age")]
        [Range(minimum: 5, maximum: 85)]
        public int PatientAge { get; set; }
    }
}
