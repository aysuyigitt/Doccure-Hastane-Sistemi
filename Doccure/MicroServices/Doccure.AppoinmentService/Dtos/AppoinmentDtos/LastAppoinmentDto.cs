namespace Doccure.AppoinmentService.Dtos.AppoinmentDtos
{
    public class LastAppoinmentDto
    {
        public int AppointmentId { get; set; }
        public string DoctorId { get; set; }
        public string BranchId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Diagnosis { get; set; }
        public string Status { get; set; }
    }
}
