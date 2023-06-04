﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        Task<int> Commit(CancellationToken cancellationToken);
    }
}