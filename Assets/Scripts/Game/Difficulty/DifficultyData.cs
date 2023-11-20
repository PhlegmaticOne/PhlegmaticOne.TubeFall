namespace Game.Difficulty {
    public readonly struct DifficultyData {
        public DifficultyData(float radius, float turn) {
            Radius = radius;
            Turn = turn;
        }

        public float Radius { get; }
        public float Turn { get; }
    }
}