using System;
using System.Globalization;
using SCILL;
using SCILL.Api;
using UnityEngine;

namespace DefaultNamespace
{
    public class MyLeaderboard : SCILLLeaderboard
    {
        [SerializeField] private string start;
        [SerializeField] private string end;

        protected override void LoadLeaderboardRankings(int page, int customPageSize, bool clear = false)
        {
            if (null != SCILLManager.Instance.SCILLClient && !IsLoading)
            {
                CultureInfo culture = CultureInfo.CreateSpecificCulture("de-DE");
                DateTimeStyles style = DateTimeStyles.AdjustToUniversal;

                if (DateTime.TryParse(start, culture, style, out DateTime startDate) &&
                    DateTime.TryParse(end, culture, style, out DateTime endDate))
                {
                    IsLoading = true;
                    LeaderboardApiOptionalParameters dates = new LeaderboardApiOptionalParameters
                    {
                        StartDate = startDate,
                        EndDate = endDate
                    };
                    SCILLManager.Instance.SCILLClient.GetLeaderboardAsync(leaderboardId, page, customPageSize,
                        optionalParameters: dates).Then(result => { UpdateLeaderboardUI(clear, result); }).Catch(e =>
                    {
                        Debug.Log($"Failed to fetch the leaderboard: {e}");
                    });
                }
            }
        }
    }
}