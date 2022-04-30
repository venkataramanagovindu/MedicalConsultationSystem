using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalConsultationSystem.Models
{
    public class Room
    {
        public int ID { get; set; }
        public string RoomNumber { get; set; }
        public int PatientId { get; set; }

        public Patient Patient { get; set; }
    }
}
