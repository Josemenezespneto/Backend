public class CreateTaskDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Status { get; set; }
    public int? UserId { get; set; }
}