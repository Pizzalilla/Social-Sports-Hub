using System.Threading.Tasks;
using Social_Sport_Hub.Models;

namespace Social_Sport_Hub.Services
{
    public sealed class HonorService : IHonorService
    {
        private readonly IRepository<User> _users;
        private readonly IRepository<HonorHistoryRecord> _audits;

        public event EventHandler<HonorChangedEventArgs>? HonorChanged;

        public HonorService(IRepository<User> users, IRepository<HonorHistoryRecord> audits)
        {
            _users = users;
            _audits = audits;
        }

        public async Task ApplyAttendanceResultAsync(User participant, bool attended, string reason = "")
        {
            var delta = attended ? +5 : -10;
            participant.HonorScore += delta;

            await _users.UpdateAsync(participant);
            await _audits.AddAsync(new HonorHistoryRecord
            {
                UserId = participant.Id,
                ChangeAmount = delta,
                Reason = string.IsNullOrWhiteSpace(reason) ? (attended ? "Attended event" : "No-show") : reason
            });

            await _users.SaveChangesAsync();
            await _audits.SaveChangesAsync();

            HonorChanged?.Invoke(this, new HonorChangedEventArgs(participant.Id, participant.HonorScore, delta));
        }
    }
}
