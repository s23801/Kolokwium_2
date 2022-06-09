using Kolokwium_2.Models;
using Kolokwium_2.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium_2.Services
{
    public class DbService : IDbService
    {
        private readonly MainDbContext _dbContext;

        public DbService(MainDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        public async Task<IEnumerable<MusicianToGet>> GetMusician(int id)
        {
            return await _dbContext.Musicians
           .Include(e => e.Musician_Tracks)
           .Select(e => new MusicianToGet
           {
               IdMusician = id,
               FirstName = e.FirstName,
               LastName = e.LastName,
               Nickname = e.Nickname,
               Tracks = (ICollection<Track>)e.Musician_Tracks.Select(e => e.IdMusician == id).ToList()
           })
           .OrderByDescending(e => e.Tracks)
           .ToListAsync();
        }

        public Task GetMusician()
        {
            throw new NotImplementedException();
        }

        public async Task RemoveMusician(int id)
        {
            var musician = await _dbContext.Musicians.Where(e => e.IdMusician == id).FirstOrDefaultAsync();
            _dbContext.Remove(musician);
            await _dbContext.SaveChangesAsync();
        }
    }
}

