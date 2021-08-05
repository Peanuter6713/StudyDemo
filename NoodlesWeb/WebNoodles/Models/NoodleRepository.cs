using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebNoodles.Models
{
    public class NoodleRepository : INoodleRepository
    {
        private readonly AppDbContext dbContext;

        public NoodleRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Noodle> GetAllNoodles()
        {
            return dbContext.Noodles;
        }

        public Noodle GetNoodleById(int id)
        {
            return dbContext.Noodles.FirstOrDefault(n => n.Id == id);
        }

    }
}
