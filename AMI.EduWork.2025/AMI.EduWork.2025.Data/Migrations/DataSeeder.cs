﻿using AMI.EduWork._2025.Domain;
using AMI.EduWork._2025.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork._2025.Data.Migrations
{
    public class DataSeeder
    {
        private readonly ApplicationDbContext _context;
        public DataSeeder(ApplicationDbContext context) {
            _context = context;
        }

        public void SeedData()
        {
            var user = new ApplicationUser()
            {
                Email = "test1@gamail.com",
                UserName = "test1",
                EmailConfirmed = false,
                PhoneNumberConfirmed = true,
                PhoneNumber = "1111111"
            };
            _context.Add(user);

            _context.Add(new Contract()
            {
                Id = Guid.NewGuid().ToString(),
                UserId = user.Id,
                WorkingHour = 8,
                IsActive = true,
                HourlyRate = 10,
            });
            var project = new Project()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Test",
                TypeOfProject = 1,
                Description = "Test Test Test Test Test ",
            };
            _context.Add(project);

            var workDay = new WorkDay()
            {
                Id = Guid.NewGuid().ToString(),
                Date = DateTime.Now,
            };
            _context.Add(workDay);

            _context.Add(new TimeSlice()
            {
                Id = Guid.NewGuid().ToString(),
                WorkDayId = workDay.Id,
                ProjectId = project.Id,
                Start = DateTime.Now,
                End = DateTime.Now.AddMinutes(10),
                TypeOfSlice = 1,
                UserId = user.Id,
            });

            _context.Add(new UserOnProject()
            {
                Id = Guid.NewGuid().ToString(),
                UserId = user.Id,
                ProjectId = project.Id,
                ProjectRole = "tester",
                RoleStartDate = DateTime.Now,
                RoleEndDate = DateTime.Now.AddMinutes(10),

            });

            _context.Add(new SickLeave()
            {
                Id = Guid.NewGuid().ToString(),
                UserId = user.Id,
                StartDate = DateOnly.FromDateTime(DateTime.Now),
                EndDate = DateOnly.FromDateTime(DateTime.Now.AddDays(5)),
                Year = 1000
            });

            var vacation = new AnnualVacation()
            {
                Id = Guid.NewGuid().ToString(),
                UsedVacation = 0,
                Year = 1000,
                PlannedVacation = 0,
                AvailableVacation = 0,
            };

            _context.Add(vacation);

            _context.Add(new UserOnVacation() {
                Id = Guid.NewGuid().ToString(),
                UserId = user.Id,
                AnnualVacationId = vacation.Id,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(5),
            });

            _context.SaveChanges();
        }
    }
}
