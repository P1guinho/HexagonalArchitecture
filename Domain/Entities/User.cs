using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public sealed class User
    {
        public Guid Id { get; private set; }

        public string? Name { get; private set; }

        public string? Email { get; private set; }

        public User(string? email, string? name, Guid id)
        {
            Email = email;
            Name = name;
            Id = id;
        }

        public void AddUser(string name, string email)
        {
            Id = Guid.NewGuid();
            Validate(name, email);
            Name = name;
            Email = email;
        }

        private static void Validate(string name, string email)
        {
            if(name is null || name.Length < 3)
                throw new InvalidNameException("Invalid Name");

            if (email is null || !email.Contains("@"))
                throw new InvalidEmailException("Invalid email");
        }
    }
}
