﻿using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Installers {
    [CreateAssetMenu(fileName = "ConfigsInstaller", menuName = "Configs/Config Installer")]
    public class ConfigsInstaller : ScriptableObjectInstaller {
        [SerializeField] private List<ScriptableObject> _configs;
        [SerializeField] private Object _folder;
        [SerializeField] private Object[] _excludeFolders;

        public override void InstallBindings() => BindConfigs(_configs);

        private void BindConfigs(IEnumerable<ScriptableObject> configs) {
            foreach (var config in configs) {
                var type = config.GetType();
                Container.Bind(type).FromInstance(config).AsSingle();
            }
        }

#if UNITY_EDITOR
        [Button]
        private void UpdateConfigs() {
            _configs.Clear();
            foreach (var scriptableObject in AssetUtils.LoadAssets<ScriptableObject>(_folder, _excludeFolders)) {
                if (scriptableObject == this) {
                    continue;
                }
                    
                _configs.Add(scriptableObject);
            }
        }
#endif
    }
}