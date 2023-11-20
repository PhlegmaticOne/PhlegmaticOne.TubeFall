namespace Common.Input {
    public class InputProviderKeys : IInputProvider {
        public InputData ReadInput() {
            var hAxis = UnityEngine.Input.GetAxis("Horizontal");
            var vAxis = UnityEngine.Input.GetAxis("Vertical");
            return new InputData(hAxis, vAxis);
        }
    }
}