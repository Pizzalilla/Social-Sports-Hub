using System;
using System.Threading.Tasks;
using Social_Sport_Hub.Models;

namespace Social_Sport_Hub.Services
{
    public interface IHonorService
    {
        event EventHandler<HonorChangedEventArgs>? HonorChanged;
        Task ApplyAttendanceResultAsync(User participant, bool attended, string reason = "");
    }

    public sealed class HonorChangedEventArgs : EventArgs
    {
        public Guid UserId { get; }
        public int UpdatedHonorScore { get; }
        public int ChangeAmount { get; }
        public HonorChangedEventArgs(Guid id, int newScore, int delta) { UserId = id; UpdatedHonorScore = newScore; ChangeAmount = delta; }
    }
}
