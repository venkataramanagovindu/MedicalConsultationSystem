using MedicalConsultationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalConsultationSystem.Data
{
    public class DbInitializer
    {
        public static void initialize(MedicalConsultationContext context)
        {
            context.Database.EnsureCreated();
            // Look for any students.
            //if (context.Doctors.Any())
            //{
            //    return;   // DB has been seeded
            //}

            var doctors = new Doctor[]
            {
                new Doctor(){DateOfJoining = new DateTime(), FirstMidName = "Some", LastName = "Name", Specialization = Specialization.A}
            };

            foreach (Doctor d in doctors)
            {
                context.Doctors.Add(d);
            }
            context.SaveChanges();
        }
    }
}
