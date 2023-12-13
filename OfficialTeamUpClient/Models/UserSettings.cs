namespace OfficialTeamUpClient.Models
{

    public enum PrivacySetting
    {
        Public,
        FriendsOnly,
        Private
    }

    public class UserSettings
    {
        public int UserID { get; set; }

        public string Language { get; set; } = "EN-US";
        public string TimeZone { get; set; } = "EST";
        public string ThemePreference { get; set; } = "";
        public bool EnableTwoFactorAuthentication { get; set; } = false;
        public bool AllowEmailNotification { get; set; } = false;
        public PrivacySetting ProfilePrivacy { get; set; }
        public string DisplayName { get; set; } = "";
        public string Bio { get; set; } = "";
        public string SocialMediaLinks { get; set; } = "";

        public UserProfile UserProfile { get; set; }
    }
}
