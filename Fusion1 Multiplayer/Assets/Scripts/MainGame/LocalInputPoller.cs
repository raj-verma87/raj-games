using Fusion;
using Fusion.Sockets;
using System;
using System.Collections.Generic;
using UnityEngine;

public class LocalInputPoller : NetworkBehaviour, INetworkRunnerCallbacks
{
    [SerializeField] private PlayerController player;

    public override void Spawned()
    {
        if (Runner.LocalPlayer == Object.InputAuthority)
        {
            Runner.AddCallbacks(this);
        }
    }
    public void OnInput(NetworkRunner runner, NetworkInput input)
    {
        if (runner != null && runner.IsRunning)
        {
            var data = player.GetPlayerNetworkInput();
            input.Set(data);
            Debug.Log("OnInput111..." + data.HorizontalInput);
        }
    }

    public void OnConnectedToServer(NetworkRunner runner)
    {
        Debug.Log("LocalInputPoller OnConnectedToServer...");
    }

    public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
    {
        Debug.Log("LocalInputPoller OnConnectFailed...");
    }

    public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
    {
        Debug.Log("LocalInputPoller OnConnectRequest...");
    }

    public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
    {
        Debug.Log("LocalInputPoller OnCustomAuthenticationResponse...");
    }

    public void OnDisconnectedFromServer(NetworkRunner runner)
    {
        Debug.Log("LocalInputPoller OnDisconnectedFromServer...");
    }

    public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
    {
        Debug.Log("LocalInputPoller OnHostMigration...");
    }

    public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
    {
        Debug.Log("LocalInputPoller OnInputMissing...");
    }

    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
        Debug.Log("LocalInputPoller OnPlayerJoined...");
    }

    public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
    {
        Debug.Log("LocalInputPoller OnPlayerLeft...");
    }

    public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ArraySegment<byte> data)
    {
        Debug.Log("LocalInputPoller OnReliableDataReceived...");
    }

    public void OnSceneLoadDone(NetworkRunner runner)
    {
        Debug.Log("LocalInputPoller OnSceneLoadDone...");
    }

    public void OnSceneLoadStart(NetworkRunner runner)
    {
        Debug.Log("LocalInputPoller OnSceneLoadStart...");
    }

    public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
    {
        Debug.Log("LocalInputPoller OnSessionListUpdated...");
    }

    public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
    {
        Debug.Log("LocalInputPoller OnShutdown...");
    }

    public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
    {
        Debug.Log("LocalInputPoller OnUserSimulationMessage...");
    }
}


