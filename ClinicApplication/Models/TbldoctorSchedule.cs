using System;
using System.Collections.Generic;

namespace ClinicApplication.Models
{
    public partial class TbldoctorSchedule
    {
        public int ScheduleId { get; set; }
        public int DoctorId { get; set; }
        public int DayOfWeek { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public string PatientName { get; set; }
        public int? PatientAge { get; set; }
        public DateTime? Date { get; set; }

        public virtual WeekDay DayOfWeekNavigation { get; set; }
        public virtual Tbldoctor Doctor { get; set; }
    }
}
