using Backend.Enums;

public class TaskResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public StatusTask Status { get; set; }

    public int? UserId { get; set; }
}