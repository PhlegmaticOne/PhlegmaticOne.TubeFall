namespace Common.Input {
    public readonly struct InputData {
        public InputData(float horizontal, float vertical) {
            Horizontal = horizontal;
            Vertical = vertical;
        }

        public float Horizontal { get; }
        public float Vertical { get; }

        public override string ToString() {
            return $"{Horizontal};{Vertical}";
        }
    }
}