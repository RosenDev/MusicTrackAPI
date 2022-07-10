using Microsoft.EntityFrameworkCore;
using MusicTrackAPI.Data.Domain;

namespace MusicTrackAPI.Data.Repositories
{
    public class UserRepository: RepositoryBase<User>, IUserRepository
	{
        public UserRepository(MusicTrackAPIDbContext context) : base(context)
        {
        }

        public async Task<User> GetUserAsync(string username, CancellationToken ct = default)
        {
            return await Set.FirstOrDefaultAsync(x => x.Username == username, ct);
        }
    }
}

