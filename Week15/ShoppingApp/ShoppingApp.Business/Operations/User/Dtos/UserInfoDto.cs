﻿using ShoppingApp.Data.Enums;
using ShoppingApp.Data.Enums;

namespace ShoppingApp.Business.Operations.User.Dtos
{
    public class UserInfoDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public UserType UserType { get; set; }
    }
}