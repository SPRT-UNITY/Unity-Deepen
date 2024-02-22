using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Map : MonoBehaviour
{
    [field: SerializeField]
    public SpawnPoint spawnPoint { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        if(spawnPoint == null)
            spawnPoint = GetComponentInChildren<SpawnPoint>();
        Assert.IsNotNull(spawnPoint);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        if(spawnPoint == null) 
        {
            Debug.LogError("spawnPoint Null!");
        }
    }
}
