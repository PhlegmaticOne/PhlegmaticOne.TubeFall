namespace Common.State.Services {
    public class CoinService : ICoinService {
        private readonly IPlayerStateRepository _playerStateRepository;

        public CoinService(IPlayerStateRepository playerStateRepository) {
            _playerStateRepository = playerStateRepository;
        }
        
        public void ChangeCoins(int delta) {
            _playerStateRepository.GetState().CoinsCount += delta;
        }

        public int CoinsCount => _playerStateRepository.GetState().CoinsCount;
    }
}