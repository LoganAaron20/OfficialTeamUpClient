namespace OfficialTeamUpClient.Models
{
    public class ContentPreferences
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public bool ShowImages { get; set; } = true;
        public bool ShowVideos { get; set; } = true;
        public UserProfile UserProfile { get; set; }
    }
}
