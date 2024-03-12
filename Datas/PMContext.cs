using Microsoft.EntityFrameworkCore;

namespace Datas
{
    public class PMContext : DbContext
    {
        public PMContext(DbContextOptions<PMContext> options) : base(options)
        {
        }
    }
}
