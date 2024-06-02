using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LoadingCanvasController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Button cancelBtn;
    private NetworkRunnerController networkRunnerController;

    // Start is called before the first frame update
    void Start()
    {
        networkRunnerController = GlobalManager.Instance.networkRunnerController;
        networkRunnerController.OnPlayerJoinedSuccessfully +=OnPlayerJoinedSuccessfully;
        networkRunnerController.OnStartedRunnerConnection += OnStartedRunnerConnection;

        cancelBtn.onClick.AddListener(networkRunnerController.ShutDownRunner);
        this.gameObject.SetActive(false);
    }

    private void OnStartedRunnerConnection()
    {
        this.gameObject.SetActive(true);
        const string CLIP_NAME = "In";
        StartCoroutine(Utils.PlayAnimAndSetStateWhenFinished(gameObject, animator, CLIP_NAME));
    }

    private void OnPlayerJoinedSuccessfully()
    {
        const string CLIP_NAME = "Out";
        StartCoroutine(Utils.PlayAnimAndSetStateWhenFinished(gameObject, animator, CLIP_NAME, false));
    }

    private void OnDestroy()
    {
        networkRunnerController.OnPlayerJoinedSuccessfully -= OnPlayerJoinedSuccessfully;
        networkRunnerController.OnStartedRunnerConnection -= OnStartedRunnerConnection;
    }
}
