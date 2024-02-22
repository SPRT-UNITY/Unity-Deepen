using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Map : MonoBehaviour
{
    [SerializeField]
    SpawnPoint spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
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
