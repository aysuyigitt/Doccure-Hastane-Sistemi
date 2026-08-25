namespace Doccure.AppoinmentService.Entities
{
    public class Appointment
    {
        public int AppointmentId { get; set; }

        public string DoctorId { get; set; }   // MongoDB'den gelecek
        public string PatientId { get; set; }  // Identity'den gelecek

        public string? BranchId { get; set; }

        public DateTime AppointmentDate { get; set; }

        public string Status { get; set; } // Pending, Approved, Cancelled

        public decimal Price { get; set; }


        // One-to-One ilişki
        public AppointmentDetail AppointmentDetail { get; set; }


        // Appointment - DoctorSchedule ilişkisi
        public List<DoctorSchedule> DoctorSchedules { get; set; }
    }
}