using System;
using System.Collections.Generic;

namespace ClinicApplication.Models
{
    public partial class Tbldoctor
    {
        public Tbldoctor()
        {
            DoctorWorkDays = new HashSet<DoctorWorkDay>();
            TbldoctorSchedules = new HashSet<TbldoctorSchedule>();
        }

        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string About { get; set; }
        public int? ClinicId { get; set; }

        public virtual Tblclinic Clinic { get; set; }
        public virtual ICollection<DoctorWorkDay> DoctorWorkDays { get; set; }
        public virtual ICollection<TbldoctorSchedule> TbldoctorSchedules { get; set; }
    }
}
