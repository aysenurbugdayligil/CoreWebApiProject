namespace AspNetCoreWebAPI.Model {
    public class User {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
    }

    public class UserRequestModel {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
    }
}