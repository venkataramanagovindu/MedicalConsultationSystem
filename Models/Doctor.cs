using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalConsultationSystem.Models
{
    public enum Specialization
    {
        General, 
        Cardiologist,
        Orthopedics,
        [Display(Name= "General Surgery")]
        GeneralSurgery,
        Ophthalmology,
        [Display(Name = "Family Physicians")]
        FamilyPhysicians,
        Neurologists,
        gynecologist
    }

    public class Doctor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime DateOfJoining { get; set; }
        public Specialization Specialization { get; set; }

        public ICollection<Patient> Patients { get; set; }
    }
}
