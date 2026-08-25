namespace Doccure.AppoinmentService.Dtos.AppoinmentDtos
{
    public class CreateAppoinmentDto
    {
        public string DoctorId { get; set; }
        public string PatientId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public decimal Price { get; set; }
    }
}
