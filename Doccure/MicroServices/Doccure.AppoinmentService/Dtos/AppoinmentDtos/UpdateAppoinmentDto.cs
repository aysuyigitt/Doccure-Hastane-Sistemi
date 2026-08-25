namespace Doccure.AppoinmentService.Dtos.AppoinmentDtos
{
    public class UpdateAppoinmentDto
    {
        public int AppointmentId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; }
    }
}
