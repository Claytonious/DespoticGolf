using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField]
        private PhysicalGolfball _itemToSpawn;
        
        private IEnumerator Start()
        {
            const int numToSpawn = 100;
            for (int i = 0; i < numToSpawn; i++)
            {
                yield return new WaitForSeconds(Random.Range(0f, 0.2f));
                var pos = transform.position + Random.onUnitSphere * Random.Range(0.1f, 0.5f);
                Instantiate(_itemToSpawn, pos, Quaternion.identity);
            }
        }
    }
}