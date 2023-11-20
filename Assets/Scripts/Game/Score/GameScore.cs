namespace Game.Score {
    public readonly struct GameScore {
        public GameScore(int currentScore, int maxScore) {
            CurrentScore = currentScore;
            MaxScore = maxScore;
        }

        public int CurrentScore { get; }
        public int MaxScore { get; }
    }
}