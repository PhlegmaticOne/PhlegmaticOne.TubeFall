namespace Common.State {
    public interface IPlayerStateRepository {
        PlayerState GetState();
        void SaveState();
    }
}