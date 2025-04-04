﻿using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Abstraction;
using EasyLearning.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EasyLearning.Infrastructure.Data.Repostiory
{
    public class OrderDetailRepository : GenericRepository<OrderDetail>
    {
        public OrderDetailRepository(EasyLearningDbContext dbContext, UserRepository userRepository) : base(dbContext, userRepository)
        { }
        public async Task<bool> CheckIfUserHasBoughtCourse(string userId, string courseId)
        {
            return await _dbContext.OrderDetails.AnyAsync(x => x.Order.UserId == userId && x.CoursesId == courseId);
        }

    }
}
