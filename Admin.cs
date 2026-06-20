using PostNamespace;
using NotificationNamespace;


namespace AdminNamespace
{
    public class Admin
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public Post[] Posts { get; set; }

        public Notification[] Notifications { get; set; }
    }
}
