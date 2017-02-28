﻿using Habitual.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habitual.Core.Repositories
{
    public interface TodoRepository : Repository<Todo>
    {
        Todo MarkDone(Todo todo);
    }
}
