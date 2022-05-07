namespace JMR.Models
{
  public class PostViewModel
  {
    public string? Title { get; set; }
    public string? Description { get; set; }
    public int minPay { get; set; }
    public int maxPay { get; set; }
    public int timeFrame { get; set; }
    public string timeUnit { get; set; }
    public List<string> skillsIds { get; set; }
  }
}
