namespace Habitual.Core.Entities
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public byte[] Avatar { get; set; }
        public int Points { get; set; }
    }
}
