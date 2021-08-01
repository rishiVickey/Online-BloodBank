﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Models.Model.Authentication.Interfaces
{
   public interface ITokenService
   {
        string CreateToken(ApplicationUser user);
   }
}
