using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SendData : NetworkBehaviour {

    bool success = false;

    public ReceiveData rd;

    private void Awake()
    {
        rd = FindObjectOfType<ReceiveData>();
    }

    void Update()
    {
        //if(!isLocalPlayer)
        //{
        //    return;
        //}

        if(Input.GetKeyDown(KeyCode.Q))
        {
            success = true;
            rd.CmdGetSuccess(success);
        }
        else if(Input.anyKeyDown)
        {
            success = false;
            rd.CmdGetSuccess(success);
        }
    }
}
