using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Assertions;

public class GameSceneManager : MonoBehaviour
{
    Map map;
    Player player;

    private void Awake()
    {
        player = FindFirstObjectByType<Player>();
    }

    // Start is called before the first frame update
    void Start()
    {
        InitGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InitGame() 
    {
        CreateAndSpawnMap();
        CreateCharacter();
        SpawnCharacter();
    }

    void CreateAndSpawnMap() 
    {
        GameObject mapObject = Addressables.LoadAssetAsync<GameObject>("Map0").WaitForCompletion();
        mapObject = Instantiate(mapObject);
        map = mapObject.GetComponent<Map>();
    }

    void CreateCharacter() 
    {
        GameObject playerObject = Addressables.LoadAssetAsync<GameObject>("Player0").WaitForCompletion();
        playerObject = Instantiate(playerObject);
        player.Possess(playerObject.GetComponent<PlayerCharacterController>());
    }

    void SpawnCharacter() 
    {
        player.possessedCharacterController.transform.position = map.spawnPoint.transform.position;
    }
}
