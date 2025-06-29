﻿using AMI.EduWork._2025.Domain.Entities;
using AMI.EduWork._2025.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork._2025.Data.Repository;

public class UserOnVacationRepository : Repository<UserOnVacation>, IUserOnVacationRepository
{
    public UserOnVacationRepository(ApplicationDbContext context) :base(context) { }
}
