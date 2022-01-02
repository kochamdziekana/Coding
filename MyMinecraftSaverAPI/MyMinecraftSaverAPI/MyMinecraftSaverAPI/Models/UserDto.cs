namespace MyMinecraftSaverAPI.Models
{
    public class UserDto
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public List<WorldDto> Worlds { get; set; }
    }
}
