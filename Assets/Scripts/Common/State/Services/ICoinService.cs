namespace Common.State.Services {
    public interface ICoinService {
        void ChangeCoins(int delta);
        int CoinsCount { get; }
    }
}