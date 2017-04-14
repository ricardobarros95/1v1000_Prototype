using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Move : NetworkBehaviour {

    bool success = false;

    public ReceiveData rd;

    private void Awake()
    {
        rd = FindObjectOfType<ReceiveData>();
    }

    private void Update()
    {
        if (!isLocalPlayer) return;

        var x = Input.GetAxis("Horizontal") * 0.1f;

        var z = Input.GetAxis("Vertical") * 0.1f;

        transform.Translate(x, 0, z);
    }

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();

        GetComponent<MeshRenderer>().material.color = Color.red;
    }
}
