﻿using Models.Columns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRepository.Interfaces
{
    public interface IBlogRepository
    {
        public Task<Page<Post>> GetPosts(int index, int pageSize, string tag = null);
    }
}
