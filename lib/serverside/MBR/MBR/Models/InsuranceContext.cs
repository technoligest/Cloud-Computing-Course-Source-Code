using System;
using Microsoft.EntityFrameworkCore;

namespace MBR.Models
{
    public class InsuranceContext:DbContext
    {

        public InsuranceContext(DbContextOptions<InsuranceContext> options) : base(options)
        {
        }
    }
}
