using Fusion;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MiddleSectionPanel : LobbyPanelBase
{
    [Header("MiddleSectionPanel Vars")]
    [SerializeField] private Button joinRandomRoomBtn;
    [SerializeField] private Button joinRoomByArgBtn;
    [SerializeField] private Button createRoomBtn;

    [SerializeField] private TMP_InputField joinRoomByArgInputField;
    [SerializeField] private TMP_InputField createRoomInputField;
    private NetworkRunnerController networkRunnerController;

    public override void InitPanel(LobbyUIManager uiManager)
    {
        base.InitPanel(uiManager);

        networkRunnerController = GlobalManager.Instance.networkRunnerController;
        joinRandomRoomBtn.onClick.AddListener(JoinRandomRoom);
        createRoomBtn.onClick.AddListener(()=> CreateRoom(GameMode.Host, createRoomInputField.text));
        joinRoomByArgBtn.onClick.AddListener(()=> CreateRoom(GameMode.Client,joinRoomByArgInputField.text));
    }
    private void CreateRoom(GameMode mode,string field)
    {
        Debug.Log("CreateRoom called..."+mode);
        if (field.Length > 2)
        {
            Debug.Log($"------------{mode}------------");
            networkRunnerController.StartGame(mode, field);
        }
    }
    private void JoinRandomRoom()
    {
        Debug.Log($"------------JoinRandomRoom!------------");
        networkRunnerController.StartGame(GameMode.AutoHostOrClient, string.Empty);
    }


    
}
