using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using Social_Sport_Hub.Models;
using Social_Sport_Hub.Services;

namespace Social_Sport_Hub.ViewModels
{
    public sealed class ProfileViewModel : BaseViewModel
    {
        private readonly IHonorService _honorService;
        private readonly IRepository<HonorHistoryRecord> _honorRepo;

        public ObservableCollection<HonorHistoryRecord> HonorTrend { get; } = new();
        public int HonorScore { get; set; }
        public string WeatherInfo { get; set; } = string.Empty;

        public ProfileViewModel(IHonorService honorService, IRepository<HonorHistoryRecord> honorRepo)
        {
            _honorService = honorService;
            _honorRepo = honorRepo;

            _honorService.HonorChanged += (s, e) =>
            {
                var avg = _honorRepo.Query()
                    .Where(a => a.UserId == e.UserId)
                    .OrderByDescending(a => a.RecordedAtUtc)
                    .Take(10)
                    .Select(a => a.ChangeAmount)
                    .DefaultIfEmpty(0)
                    .Average();
                Message = $"New honor: {e.UpdatedHonorScore}, last 10 avg: {avg:F1}";
            };
        }

        public async Task LoadUserAsync(Guid userId)
        {
            IsBusy = true;
            var history = _honorRepo.Query().Where(h => h.UserId == userId).ToList();
            HonorTrend.Clear();
            foreach (var item in history) HonorTrend.Add(item);
            IsBusy = false;
        }
    }
}
