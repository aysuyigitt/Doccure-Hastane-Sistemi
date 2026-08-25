namespace Doccure.AppoinmentService.Dtos.AppoinmentDtos
{
    public class GetAppoinmentByIdDto
    {
        public int AppointmentId { get; set; }
        public string DoctorId { get; set; }
        public string PatientId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; }
        public decimal Price { get; set; }
    }
}
