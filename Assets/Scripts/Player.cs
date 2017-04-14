using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player : NetworkBehaviour {

    bool success;

    private void Update()
    {
        if (!isLocalPlayer) return;

        RegisterInput();
    }

    void RegisterInput()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            success = true;
            CmdUpdateCount(success, 1, 0);
        }
        else if (Input.anyKeyDown)
        {
            success = false;
            CmdUpdateCount(success, 0, 1);
        }
    }

    [Command]
    void CmdUpdateCount(bool success, int tru, int fal)
    {
        Debug.Log("Haa");
        GameManager.Instance.successList.Add(success);
        GameManager.Instance.trueCount += tru;
        GameManager.Instance.falseCount += fal;
    }
}
