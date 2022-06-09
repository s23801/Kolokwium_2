using Kolokwium_2.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium_2.Services
{
    interface IDbService
    {
        Task<IEnumerable<MusicianToGet>> GetMusician(int id);
        Task RemoveMusician(int id);
        Task GetMusician();
    }
}
