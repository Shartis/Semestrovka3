﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services.Interfaces
{
    public interface IPasswordHasher
    {
        public string Hash(string password);

        
    }
}
