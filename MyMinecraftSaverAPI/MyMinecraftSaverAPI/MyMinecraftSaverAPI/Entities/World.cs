namespace MyMinecraftSaverAPI.Entities
{
    public class World  // minecraft save world
    {
        public int Id { get; set; }
        public virtual User User { get; set; }  // user who's the save is
        public string Name { get; set; }
    }
}
