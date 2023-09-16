using System;
using System.Collections.Generic;

namespace ClinicApplication.Models
{
    public partial class WeekDay
    {
        public WeekDay()
        {
            DoctorWorkDays = new HashSet<DoctorWorkDay>();
            TbldoctorSchedules = new HashSet<TbldoctorSchedule>();
        }

        public int Id { get; set; }
        public string Day { get; set; }

        public virtual ICollection<DoctorWorkDay> DoctorWorkDays { get; set; }
        public virtual ICollection<TbldoctorSchedule> TbldoctorSchedules { get; set; }
    }
}
