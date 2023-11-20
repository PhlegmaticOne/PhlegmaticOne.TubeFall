namespace Game.Base {
    public interface IUpdatable {
        void OnAwake();
        void OnUpdate(float deltaTime);
        void OnDispose();
    }
}