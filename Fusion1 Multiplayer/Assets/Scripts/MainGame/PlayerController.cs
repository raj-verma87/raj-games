using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : NetworkBehaviour , IBeforeUpdate
{
    [SerializeField] private float moveSpeed = 6;
    private float horizontal;
    private Rigidbody2D rigid;

    public override void Spawned()
    {
        rigid = GetComponent<Rigidbody2D>();

    }
    public void BeforeUpdate()
    {
        if (Runner.LocalPlayer == Object.HasInputAuthority)
        {
            const string HORIZONTAL = "Horizontal";
            horizontal = Input.GetAxisRaw(HORIZONTAL);
          //  Debug.Log("BeforeUpdate..."+ horizontal);
        }
    }
    public override void FixedUpdateNetwork()
    {
        if (Runner.TryGetInputForPlayer<PlayerData>(Object.InputAuthority, out var input))
        {
            rigid.velocity = new Vector2(input.HorizontalInput * moveSpeed , rigid.velocity.y);
            Debug.Log("FixedUpdateNetwork...");
        }
    }
    public PlayerData GetPlayerNetworkInput()
    {
        PlayerData data = new PlayerData();
        data.HorizontalInput = horizontal;
        Debug.Log("GetPlayerNetworkInput..."+data.HorizontalInput);
        return data;
    }
}
