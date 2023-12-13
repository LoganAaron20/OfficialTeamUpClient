namespace OfficialTeamUpClient.Models
{
    public class AccessibilitySettings
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string TextSize { get; set; } = "D";
        public string Contrast { get; set; } = "D";
        public UserProfile UserProfile { get; set; }
    }
}
