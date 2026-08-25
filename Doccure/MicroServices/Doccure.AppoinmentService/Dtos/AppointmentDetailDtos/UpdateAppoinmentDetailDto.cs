namespace Doccure.AppoinmentService.Dtos.AppointmentDetailDtos
{
    public class UpdateAppoinmentDetailDto
    {
        public int AppointmentDetailId { get; set; }
        public string Complaint { get; set; }
        public string Notes { get; set; }
        public string Diagnosis { get; set; }
        public string Prescription { get; set; }
    }
}
