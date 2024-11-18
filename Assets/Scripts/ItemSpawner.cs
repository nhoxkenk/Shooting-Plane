using System.Collections;
using UnityEngine;
using Utilities;

namespace PlaneShooter
{
    public class ItemSpawner : MonoBehaviour
    {
        [SerializeField] Item[] itemPrefabs;
        [SerializeField] float spawnInterval = 3f;
        [SerializeField] float spawnRadius = 3f;

        private void Start() => StartCoroutine(SpawnItems());

        IEnumerator SpawnItems()
        {
            while (true)
            {
                yield return new WaitForSeconds(spawnInterval);
                var item = Instantiate(itemPrefabs[Random.Range(0, itemPrefabs.Length)]);
                item.transform.position = (transform.position + Random.insideUnitSphere).With(z: 0) * spawnRadius;
            }
        }
    }
}
