﻿using Application.Management.Models;
using System;

namespace Application.Data.Repositories
{
    public interface IProfileRepository : IRepositorySimple<ProfileManagementModel>, IDisposable
    {
    }
}
