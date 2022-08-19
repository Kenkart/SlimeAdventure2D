using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

namespace Kaizen
{
    public class AchievementManager : SingletonComponent<AchievementManager>
    {
        private bool isInitialized;

        private void Start()
        {
            PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
            PlayGamesPlatform.InitializeInstance(config);
            PlayGamesPlatform.Activate();
            SignIn();
        }

        private void SignIn()
        {
            Social.localUser.Authenticate(success => {
                isInitialized = success;
            });
        }

        #region Achievements
        public void UnlockAchievement(string achievementID)
        {
            if (!isInitialized)
                return;
            Social.ReportProgress(achievementID, 100, success => { });
        }

        public void ShowAchievementsUI()
        {
            if (!isInitialized)
                return;
            Social.ShowAchievementsUI();
        }
        #endregion /Achievements

    }
}