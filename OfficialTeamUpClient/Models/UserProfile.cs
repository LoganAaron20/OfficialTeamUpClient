using System.Text.Json.Serialization;

namespace OfficialTeamUpClient.Models
{
    public class UserProfile
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public UserSettings UserSettings { get; set; }
        public AccessibilitySettings AccessibilitySettings { get; set; }
        public ContentPreferences ContentPreferences { get; set; }
        public byte[] ProfileImage { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsVerified { get; set; }
    }
}
