using System;
using System.Collections.Generic;

namespace ClinicApplication.Models
{
    public partial class DoctorWorkDay
    {
        public int Id { get; set; }
        public int? DayId { get; set; }
        public int? DoctorId { get; set; }

        public virtual WeekDay Day { get; set; }
        public virtual Tbldoctor Doctor { get; set; }
    }
}
