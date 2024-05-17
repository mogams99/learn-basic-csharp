using learn_basic_csharp_web.Models.EF;
using Microsoft.EntityFrameworkCore;
using BC = BCrypt.Net.BCrypt;

namespace learn_basic_csharp_web.Models
{
    public class AuthVM
    {
        public class Login
        {
            public string Username { get; set; } = string.Empty;
            public string Password { get; set; } = string.Empty;

            public Login()
            {

            }

            public string? authUserByRole()
            {
                using (var context = new ModelContext())
                {
                    var user = context.Users.Include(x => x.Role).FirstOrDefault(x => x.Username == Username);
                    if (user != null && BC.Verify(Password, user.Password))
                    {
                        if (user.Role == null) throw new Exception("Role has not found.");
                        var role_name = user.Role.Name.ToLower();
                        if (role_name == null) throw new Exception("Role name has user not found.");
                        return role_name;
                    }
                    return null;
                }
            }
        }

        public class Register
        {
            public string Name { get; set; } = string.Empty;
            public string Username { get; set; } = string.Empty;
            public string Email { get; set; } = string.Empty;
            public string Password { get; set; } = string.Empty;
            public int roleId { get; set; }
            public List<Role> Roles { get; set; } = new List<Role>();

            public Register()
            {
                var context = new ModelContext();
                Roles = context.Roles.ToList();
            }

            public static void saveUserByRole(Register input)
            {
                using (var context = new ModelContext())
                {
                    var passwordHash = BC.HashPassword(input.Password);

                    var user = new User
                    {
                        RoleId = input.roleId,
                        Username = input.Username,
                        Email = input.Email,
                        Password = passwordHash
                    };

                    context.Users.Add(user);
                    context.SaveChanges();

                    var role = context.Roles.Find(input.roleId);
                    if (role != null)
                    {
                        switch (role.Name.ToLower())
                        {
                            case "instructor":
                                var instructor = new Instructor
                                {
                                    UserId = user.Id,
                                    Name = input.Name,
                                };
                                context.Instructors.Add(instructor);
                                break;
                            case "student":
                                var student = new Student
                                {
                                    UserId = user.Id,
                                    Name = input.Name,
                                };
                                context.Students.Add(student);
                                break;
                        }
                        context.SaveChanges();
                    }
                }

            }
        }
    }
}