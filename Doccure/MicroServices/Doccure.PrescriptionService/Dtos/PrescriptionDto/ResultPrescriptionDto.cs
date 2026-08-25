namespace Doccure.PrescriptionService.Dtos.PrescriptionDto
{
    public class ResultPrescriptionDto
    {
        public int PrescriptionId { get; set; }
        public int AppointmentId { get; set; }
        public string DoctorId { get; set; }
        public string PatientId { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<PrescriptionItemDto> PrescriptionItems { get; set; }
    }
}
