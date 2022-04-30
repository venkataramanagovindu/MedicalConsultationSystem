using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalConsultationSystem.Models
{
    public enum Specialization
    {
        A, B, C, D, F
    }
    public class Doctor
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime DateOfJoining { get; set; }
        public Specialization Specialization { get; set; }

        public ICollection<Patient> Patients { get; set; }
    }
}
