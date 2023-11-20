using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game.Base {
    public class UpdatableBehavior : MonoBehaviour, IUpdatableBehaviour, IInitializable {
        private List<IUpdatable> _updatables;
        private bool _isStopped;

        [Inject]
        private void Construct(List<IUpdatable> updatables) {
            _updatables = updatables;
            _isStopped = true;
        }

        public void Initialize() {
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
            Continue();
        }

        public void Continue() => _isStopped = false;

        public void Stop() => _isStopped = true;

        public void Dispose() {
            foreach (var updatable in _updatables) {
                updatable.OnDispose();
            }
        }

        private void Start() {
            foreach (var updatable in _updatables) {
                updatable.OnAwake();
            }
        }

        private void Update() {
            if (_isStopped) {
                return;
            }

            var deltaTime = Time.deltaTime;
            
            foreach (var updatable in _updatables) {
                updatable.OnUpdate(deltaTime);
            }
        }
    }
}