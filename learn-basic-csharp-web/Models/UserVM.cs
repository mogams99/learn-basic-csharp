using learn_basic_csharp_web.Models.EF;
using Microsoft.EntityFrameworkCore;
using BC = BCrypt.Net.BCrypt;

namespace learn_basic_csharp_web.Models
{
    public class UserVM
    {
        public class Index
        {
            public List<User> Users { get; set; } = new List<User>();
            public Index()
            {
                using (var context = new ModelContext())
                {
                    Users = context.Users.Include(u => u.Role).Where( x => x.DeletedAt == null).ToList();
                }
            }
        }

        public class Add
        {
            public List<Role> Roles { get; set; } = new List<Role>();
            public User User { get; set; } = new User();
            public Add()
            {
                using (var context = new ModelContext())
                {
                    Roles = context.Roles.Where(x => x.DeletedAt == null).ToList();
                }
            }
        }

        public class Edit
        {
            public int Id { get; set; }
            public List<Role> Roles { get; set; } = new List<Role>();
            public User User { get; set; } = new User();
            public Edit()
            {

            }
            public Edit(int id)
            {
                using (var context = new ModelContext())
                {
                    Roles = context.Roles.Where(x => x.DeletedAt == null).ToList();
                    var query = context.Users.Include(u => u.Role).FirstOrDefault(x => x.Id == id);
                    if (query != null)
                    {
                        query.Password = "";
                        User = query;
                    }
                }
            }
        }

        public class Delete
        {
            public required int Id { get; set; }
            public Delete()
            {

            }
        }

        public static async Task<bool> Save(Add input)
        {
            using (var context = new ModelContext())
            {
                if (string.IsNullOrEmpty(input.User.Username)) throw new Exception("Username is required");
                if (string.IsNullOrEmpty(input.User.Email)) throw new Exception("Email is required");
                if (string.IsNullOrEmpty(input.User.Password)) throw new Exception("Password is required");

                var _add = new EF.User();
                _add.RoleId = input.User.RoleId;
                _add.Username = input.User.Username;
                _add.Email = input.User.Email;
                _add.Password = BC.HashPassword(input.User.Password);
                _add.IsActive = input.User.IsActive;

                context.Users.Add(_add);
                await context.SaveChangesAsync();
                return true;
            }
        }

        public static async Task<bool> Update(Edit input)
        {
            using (var context = new ModelContext())
            {
                var query = await context.Users.FirstOrDefaultAsync(x => x.Id == input.Id);

                if (query == null) throw new Exception("Data not found.");
                if (string.IsNullOrEmpty(input.User.Username)) throw new Exception("Username is required");
                if (string.IsNullOrEmpty(input.User.Email)) throw new Exception("Email is required");

                query.RoleId = input.User.RoleId;
                query.Username = input.User.Username;
                query.Email = input.User.Email;
                if (!string.IsNullOrEmpty(input.User.Password)) query.Password = BC.HashPassword(input.User.Password);
                query.IsActive = input.User.IsActive;
                query.UpdatedAt = DateTime.Now;

                await context.SaveChangesAsync();
                return true;
            }
        }

        public static async Task<bool> Destroy(Delete input)
        {
            using (var context = new ModelContext())
            {
                var query = await context.Users.FirstOrDefaultAsync(x => x.Id == input.Id);
                
                if (query == null) throw new Exception("Data not found.");
                
                query.DeletedAt = DateTime.Now;

                await context.SaveChangesAsync();
                
                return true;
            }
        }
    }
}
