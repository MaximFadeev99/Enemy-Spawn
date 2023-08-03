using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public Enemy SpawnObject(Enemy _spawnedObject)
    {
        return Instantiate(_spawnedObject, transform.position, _spawnedObject.GetComponent<Transform>().rotation);
    }
}
