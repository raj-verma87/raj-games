using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnerController : NetworkBehaviour,IPlayerJoined , IPlayerLeft
{
    [SerializeField] private NetworkPrefabRef playerNetworkPrefab = NetworkPrefabRef.Empty;
    [SerializeField] private Transform[] spawnPoints;

    public override void Spawned()
    {
        if (Runner.IsServer)
        {
            foreach (var item in Runner.ActivePlayers)
            {
                SpawnPlayer(item);
            }
        }
    }
    private void DeSpawnPlayer(PlayerRef playerRef)
    {
        if (Runner.IsServer)
        {
            if (Runner.TryGetPlayerObject(playerRef, out var playerNetworkObject))
            {
                Runner.Despawn(playerNetworkObject);
            }
            //reset player object
            Runner.SetPlayerObject(playerRef,null);
        }
    }
    private void SpawnPlayer(PlayerRef playerRef)
    {
        if (Runner.IsServer)
        {
            var index = playerRef % spawnPoints.Length;
            var spawnPoint = spawnPoints[index].transform.position;
            var playerObj = Runner.Spawn(playerNetworkPrefab,spawnPoint,Quaternion.identity,playerRef);
            Runner.SetPlayerObject(playerRef,playerObj);
        }
    }
    public void PlayerJoined(PlayerRef player)
    {
       SpawnPlayer(player);
    }

    public void PlayerLeft(PlayerRef player)
    {
        DeSpawnPlayer(player);
    }
}
