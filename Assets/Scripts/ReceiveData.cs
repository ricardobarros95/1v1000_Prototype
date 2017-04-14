using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ReceiveData : NetworkBehaviour {

    public SyncListBool successList;

    public GameObject canv;


    [SyncVar]
    public int trueCount = 0;
    [SyncVar]
    public int falseCount = 0;

    private void Awake()
    {
        successList = new SyncListBool();

        Text trueCou = canv.transform.GetChild(0).GetChild(1).GetComponent<Text>();
        Text falseCou = canv.transform.GetChild(0).GetChild(2).GetComponent<Text>();

        trueCou.text = trueCount.ToString();
        falseCou.text = falseCount.ToString();
    }

    [Command]
    public void CmdGetSuccess(bool success)
    {
        successList.Add(success);
        if (success) trueCount++;
        else falseCount++;

        Text trueCou = canv.transform.GetChild(0).GetChild(1).GetComponent<Text>();
        Text falseCou = canv.transform.GetChild(0).GetChild(2).GetComponent<Text>();

        trueCou.text = trueCount.ToString();
        falseCou.text = falseCount.ToString();
    }
}
