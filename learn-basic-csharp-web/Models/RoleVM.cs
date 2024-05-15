using learn_basic_csharp_web.Models.EF;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;

namespace learn_basic_csharp_web.Models
{
    public class RoleVM
    {
        public class Index
        {
            public List<Role> Roles { get; set; } = new List<Role>();
            public Index()
            {
                var context = new ModelContext();
                Roles = context.Roles.ToList();
            }
        }

        public class Add
        {
            public Role Role { get; set; } = new Role();
            public Add() { }
        }

        public class Edit
        {
            public int Id { get; set; }
            public Role Role { get; set; } = new Role();
            public Edit() { }
            public Edit(int id)
            {
                var context = new ModelContext();
                var query = context.Roles.FirstOrDefault(x => x.Id == id);
                if (query != null) Role = query;
            }
        }

        public class Delete
        {
            public required int Id { get; set; }
        }

        public static async Task<bool> Update(Edit input)
        {
            bool result = false;
            var context = new ModelContext();
            var query = await context.Roles.FirstOrDefaultAsync(x => x.Id == input.Id);

            if (query == null) throw new Exception("Data not found.");
            if (string.IsNullOrEmpty(input.Role.Name)) throw new Exception("Role name is required.");

            query.Name = input.Role.Name;
            await context.SaveChangesAsync();

            return result;
        }

        public static async Task<bool> Save(Add input)
        {
            bool result = false;
            var context = new ModelContext();

            if (string.IsNullOrEmpty(input.Role.Name)) throw new Exception("Role name is required.");

            var _add = new EF.Role();
            _add.Name = input.Role.Name;

            context.Roles.Add(_add);
            await context.SaveChangesAsync();

            return result;
        }

        public static async Task<bool> Destroy(Delete input)
        {
            using (var context = new ModelContext())
            {
                var query = await context.Roles.FirstOrDefaultAsync(x => x.Id == input.Id);

                if (query == null) throw new Exception("Data not found.");

                context.Roles.Remove(query);
                await context.SaveChangesAsync();

                return true;
            }

        }
    }

}
