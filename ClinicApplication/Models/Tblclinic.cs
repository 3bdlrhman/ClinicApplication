using System;
using System.Collections.Generic;

namespace ClinicApplication.Models
{
    public partial class Tblclinic
    {
        public Tblclinic()
        {
            Tbldoctors = new HashSet<Tbldoctor>();
        }

        public int ClinicId { get; set; }
        public string ClinicName { get; set; }
        public string ClinicAddress { get; set; }

        public virtual ICollection<Tbldoctor> Tbldoctors { get; set; }
    }
}
