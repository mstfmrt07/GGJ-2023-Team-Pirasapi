using System;

namespace Pirasapi
{
    public static class GameEvents
    {
        public static Action OnLevelLoad;
        public static Action OnLevelStarted;
        public static Action OnLevelCompleted;
        public static Action OnLevelFailed;

        public static Action OnGamePaused;
        public static Action OnGameResumed;
    }
}
