using System;

namespace WpfTask10.Models
{
    public class UserModel : ICloneable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public object Clone()
        {
            return new UserModel
            {
                Id = Id,
                Name = Name,
                Phone = Phone,
                Email = Email
            };
        }
    }
}
