﻿using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Services
{
    public interface IUsersServices
    {
        IEnumerable<User> GetUserWithLongName();

    }
}
