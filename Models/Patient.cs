using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalConsultationSystem.Models
{
    public class Patient
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DoctorID { get; set; }
        public int RoomID { get; set; }

        public Doctor Doctor { get; set; }
        public Room Room { get; set; }
    }
}
