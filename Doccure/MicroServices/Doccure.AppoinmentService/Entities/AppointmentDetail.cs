namespace Doccure.AppoinmentService.Entities
{
    public class AppointmentDetail
    {
        public int AppointmentDetailId { get; set; }


        // Foreign Key
        public int AppointmentId { get; set; }


        public string Complaint { get; set; }       // Şikayet

        public string Notes { get; set; }           // Doktor notu

        public string Diagnosis { get; set; }       // Teşhis

        public string Prescription { get; set; }    // Reçete


        public bool IsFirstVisit { get; set; }

        public DateTime? CompletedDate { get; set; }


        // Navigation Property
        public Appointment Appoinment { get; set; }
    }
}