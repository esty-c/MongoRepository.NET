It implements a Repository pattern on top of Official MongoDB C# driver. 

<pre><code>
  private static void Main(string[] args)
        {
            IUnitOfWork uow = new UnitOfWork();
            var repo = new UserRepository(uow);

            //Add new Item
            User newUser = new User();
            newUser.Name = "User1";
            newUser.Address = "User address";
            var result = repo.Add(newUser);


            //Get All Data

            var list = repo.All();

            //Get data using pagging
            int page = 1;
            int pageSize = 10;
            var listWithPagging = repo.All(page, pageSize);

            //Find Single
            var singleUser = repo.Single(x => x.Name.Equals("User1"));

            //Delete User
            repo.Delete(x => x.Name.Equals("User1"));

            Console.ReadLine();
        }
</code></pre>
