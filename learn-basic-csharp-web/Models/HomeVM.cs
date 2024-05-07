namespace learn_basic_csharp_web.Models
{
    public class HomeVM
    {
        public class Index
        {
            public List<TBUser> UserList { get; set; } = new List<TBUser>();
            public Index()
            {
                //$data = [
                //    "id" => "1"                
                //    "id" => "1"                
                //    "id" => "1"                
                //]

                //UserList.Add(new TBUser() { Id = 1, Name = "JOKO", Description = "JOKO ganteng", Title = "MANAGER"});
                //UserList.Add(new TBUser() { Id = 2, Name = "a", Description = "a ganteng", Title = "MANAGER"});
                //UserList.Add(new TBUser() { Id = 3, Name = "das", Description = "JdasaOKO ganteng", Title = "MANAGER"});
                //UserList.Add(new TBUser() { Id = 4, Name = "JOKasdsdO", Description = "JOKeqweqwO ganteng", Title = "MANAGER"});
                //UserList.Add(new TBUser() { Id = 5, Name = "JOqweqwewKO", Description = "JOdasdasdKO ganteng", Title = "MANAGER"});


                UserList = new List<TBUser>()
                {
                    new TBUser(){ Id = 1, Name = "JOKO", Description = "JOKO ganteng", Title = "MANAGER"},
                    new TBUser(){ Id = 2, Name = "a", Description = "a ganteng", Title = "MANAGER"},
                    new TBUser(){ Id = 3, Name = "das", Description = "JdasaOKO ganteng", Title = "MANAGER"},
                    new TBUser(){ Id = 4, Name = "JOKasdsdO", Description = "JOKeqweqwO ganteng", Title = "MANAGER"},
                    new TBUser(){ Id = 5, Name = "JOqweqwewKO", Description = "JOdasdasdKO ganteng", Title = "MANAGER"},
                };
            }
        }   

        public class Detail
        {
            public TBUser UserRow { get; set; } = new TBUser();
            public Detail(int id)
            {
                var userListDb = new List<TBUser>()
                {
                    new TBUser(){ Id = 1, Name = "JOKO", Description = "JOKO ganteng", Title = "MANAGER"},
                    new TBUser(){ Id = 2, Name = "a", Description = "a ganteng", Title = "MANAGER"},
                    new TBUser(){ Id = 3, Name = "das", Description = "JdasaOKO ganteng", Title = "MANAGER"},
                    new TBUser(){ Id = 4, Name = "JOKasdsdO", Description = "JOKeqweqwO ganteng", Title = "MANAGER"},
                    new TBUser(){ Id = 5, Name = "JOqweqwewKO", Description = "JOdasdasdKO ganteng", Title = "MANAGER"},
                };

                var user = userListDb.FirstOrDefault(x => x.Id == id);
                if (user == null) throw new Exception("user tidak ditemukan");

                UserRow = user;
            }
        }

        public class Privacy
        {

        }

        public class TBUser
        {
            public int Id { get; set; }
            public string? Name { get; set; }
            public string? Description { get; set; }
            public string? Title { get; set; }
        }
    }
}
