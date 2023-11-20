using UnityEngine;

namespace Common.Input {
    public class InputProviderTouch : IInputProvider {
        private readonly float _screenWidth;
        private readonly float _screenHeight;
        
        public InputProviderTouch() {
            _screenWidth = Screen.width;
            _screenHeight = Screen.height;
        }
        
        public InputData ReadInput() {
            if (UnityEngine.Input.touchCount <= 0) {
                return new InputData(0, 0);
            }
            
            var input = UnityEngine.Input.GetTouch(0);
            
            if (input.phase != TouchPhase.Canceled && input.phase != TouchPhase.Ended) {
                var x = -1f + 2 * input.position.x / _screenWidth;
                var y = -1f + 2 * input.position.y / _screenHeight;
                return new InputData(x, y);
            }

            return new InputData(0, 0);
        }
    }
}