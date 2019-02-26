using System;
using System.Collections;
using System.IO;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField]
        private PhysicalGolfball _itemToSpawn;
        
        private IEnumerator Start()
        {
            yield return LoadGolfball(prefab =>
            {
                if (prefab != null)
                {
                    _itemToSpawn = prefab.GetComponent<PhysicalGolfball>();
                    Debug.Log("Loaded");
                }
            });
            
            const int numToSpawn = 100;
            for (int i = 0; i < numToSpawn; i++)
            {
                yield return new WaitForSeconds(Random.Range(0f, 0.2f));
                var pos = transform.position + Random.onUnitSphere * Random.Range(0.1f, 0.5f);
                Instantiate(_itemToSpawn.gameObject, pos, Quaternion.identity);
            }
        }

        private IEnumerator LoadGolfball(Action<GameObject> handler)
        {
            var loadRequest = AssetBundle.LoadFromFileAsync(
                Path.Combine(Application.dataPath, "..", "AssetBundles", GetTargetName(), "golfballs"));
            yield return loadRequest;
            var assetBundle = loadRequest.assetBundle;
            if (assetBundle == null)
            {
                Debug.LogError("Failed to load golf balls!");
            }
            else
            {
                var prefab = assetBundle.LoadAsset<GameObject>("PhysicalGolfball");
                handler(prefab);
                assetBundle.Unload(false);                
            }
        }

        private string GetTargetName()
        {
#if UNITY_STANDALONE_OSX
            return "StandaloneOSX";
#elif UNITY_STANDALONE
            return "StandaloneWindows64";
#elif UNITY_IOS
            return "iOS";
#elif UNITY_ANDROID
            return "Android";
#else
            return "Unknown";
#endif
        }
    }
}