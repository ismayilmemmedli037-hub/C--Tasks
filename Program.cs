using AdminNamespace;
using NotificationNamespace;
using PostNamespace;
using System;
using System.Drawing;
using UserNamespace;

class Program
{
    static Admin admin = new Admin();
    static int notindex = 0;
    static void AddNot(string text, string fromUser)
    {
        admin.Notifications[notindex] = new Notification
        {
            Id = notindex + 1,
            Text = text,
            DateTime = DateTime.Now,
            FromUser = fromUser
        };
        notindex++;
    }

    static void Main(string[] args)
    {
        // ////////////////////////////////////////////////////////////
        admin.Id = 1;
        admin.Username = "Kamran";
        admin.Email = "Kamran@gmail.com";
        admin.Password = "12345";
        admin.Posts = new Post[2];
        // //////////////////////////////////////
        admin.Posts[0] = new Post
        {
            Id = 1,
            Content = "Dumanla gezinti",
            CreationDateTime = DateTime.Now,
            LikeCount = 15,
            ViewCount = 100
        };
        // //////////////////////////////////////
        admin.Posts[1] = new Post
        {
            Id = 2,
            Content = "Aqua Park Party",
            CreationDateTime = DateTime.Now,
            LikeCount = 20,
            ViewCount = 150
        };
        // ////////////////////////////////////////////////////////////
        admin.Notifications = new Notification[10];
        // ////////////////////////////////////////////////////////////
        User user = new User();
        user.Id = 1;
        user.Name = "ismayil";
        user.Surname = "Memmedli";
        user.Age = 16;
        user.Email = "ismayil@gmail.com";
        user.Password = "123456";
        // ////////////////////////////////////////////////////////////
        while (true)
        {
            Console.WriteLine("1 - User");
            Console.WriteLine("2 - Admin");
            Console.Write("Secimini daxil et: ");
            string secim = Console.ReadLine();

            if (secim == "1")
            {
                Console.WriteLine();
                Console.WriteLine("User login");
                Console.Write("Username: ");
                string username = Console.ReadLine();
                Console.Write("Password: ");
                string password = Console.ReadLine();

                if (username == user.Name && password == user.Password)
                {
                    Console.WriteLine();
                    Console.WriteLine("Login duzgundu");

                    bool exit = false;
                    while (!exit)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Postlar:"); 
                        Console.WriteLine("0 - Cixis");
                        for (int i = 0; i < admin.Posts.Length; i++)
                        {
                            Console.WriteLine($"{admin.Posts[i].Id} - {admin.Posts[i].Content}");
                        }

                        Console.Write("Postun id daxil et: ");
                        string secim2 = Console.ReadLine();
                        Console.WriteLine();

                        if (!int.TryParse(secim2, out int id))
                        {
                            Console.WriteLine("Duzgun deyer daxil et:");
                            continue;
                        }

                        if (id == 0)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Cixildi");
                            exit = true;
                            continue;
                        }

                        if (id < 1 || id > admin.Posts.Length)
                        {
                            Console.WriteLine("Bele id post yoxdu");
                            continue;
                        }

                        Post post = admin.Posts[id - 1];
                        post.ViewCount++;
                        post.ViewCount++;
                        AddNot($"Posta baxildi: {post.Content}", user.Name);

                        Console.WriteLine();
                        Console.WriteLine("Post: " + post.Content);
                        Console.WriteLine("Like edilsin?");
                        Console.WriteLine("1 - Beli");
                        Console.WriteLine("2 - Xeyr");
                        Console.Write("Secimini daxil et: ");
                        string like = Console.ReadLine();

                        if (like == "1")
                        {
                            post.LikeCount++;
                            AddNot($"Like olundu: {post.Content}", user.Name);
                            Console.WriteLine();
                            Console.WriteLine("Post like olundu");
                        }
                        else if (like == "2")
                        {
                            Console.WriteLine();
                            Console.WriteLine("Like olunmadi");
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Duzgun secim et");
                        }
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Sehv username ve ya sifre");
                    Console.WriteLine();
                }
            }

            else if (secim == "2")
            {
                Console.WriteLine();
                Console.WriteLine("Admin login");
                Console.Write("Admin name: ");
                string adminname = Console.ReadLine();
                Console.Write("Password: ");
                string password = Console.ReadLine();
                if (adminname == admin.Username && password == admin.Password)
                {
                    Console.WriteLine();
                    Console.WriteLine("ADMIN PANEL");
                    Console.WriteLine("1 - Postlari gor");
                    Console.WriteLine("2 - Notificationlar");
                    Console.Write("Secim: ");

                    string adminSecim = Console.ReadLine();
                    Console.WriteLine($"Total notifications: {notindex}");
                    if (adminSecim == "1")
                    {
                        Console.WriteLine();
                        for (int i = 0; i < admin.Posts.Length; i++)
                        {
                            Console.WriteLine($"{admin.Posts[i].Id} - {admin.Posts[i].Content} | Likes: {admin.Posts[i].LikeCount} | Views: {admin.Posts[i].ViewCount}");
                        }
                    }
                    else if (adminSecim == "2")
                    {
                        Console.WriteLine();
                        for (int i = 0; i < notindex; i++)
                        {
                            Console.WriteLine($"{admin.Notifications[i].Text} | From: {admin.Notifications[i].FromUser} | {admin.Notifications[i].DateTime}");
                            Console.WriteLine();
                        }
                    }
                }

                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Sehv adminname ve ya sifre");
                    Console.WriteLine();
                }

            }

            else {
                Console.WriteLine();
                Console.WriteLine("Duzgun secim et");
                Console.WriteLine();
            }
        }
    }
}

