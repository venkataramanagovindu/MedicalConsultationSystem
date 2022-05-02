using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalConsultationSystem.Models
{
    public class Patient
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DoctorID { get; set; }
        public int RoomID { get; set; }
        public double SpO2 { get; set; }
        public double Pulse { get; set; }
        public double temperature { get; set; }
        public double Respirationrate { get; set; }


        public Doctor Doctor { get; set; }
        public Room Room { get; set; }
    }
}
