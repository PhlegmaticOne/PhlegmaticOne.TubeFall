namespace Game.Difficulty {
    public interface IDifficulty {
        DifficultyData CalculateDifficulty(float time);
    }
}