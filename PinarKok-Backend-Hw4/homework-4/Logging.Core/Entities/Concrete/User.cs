﻿using Logging.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logging.Entities.Concrete
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public DateTime AddedAt { get; set; }
    }
}
