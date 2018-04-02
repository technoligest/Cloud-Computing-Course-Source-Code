using Microsoft.EntityFrameworkCore;

namespace MBR.Models
{
    public class BrokerContext : DbContext
    {
        public BrokerContext(DbContextOptions<BrokerContext> options): base(options)
        {
        }
       
    }

}
