using UnityEngine;

namespace Common.Input {
    public class InputProviderAcceleration : IInputProvider {
        public InputProviderAcceleration() {
            UnityEngine.Input.gyro.enabled = false;
            UnityEngine.Input.gyro.enabled = true;
        }
        
        public InputData ReadInput() {
            var acceleration = UnityEngine.Input.acceleration;
            var hAxis = Mathf.Clamp(acceleration.x, -1, 1);
            var vAxis = Mathf.Clamp(acceleration.y, -1, 1);
            return new InputData(hAxis, vAxis);
        }
    }
}