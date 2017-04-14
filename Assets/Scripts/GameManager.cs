using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GameManager : NetworkBehaviour
{

    #region Singleton
    private static GameManager _Instance;
    public static GameManager Instance
    {
        get
        {
            if (_Instance == null)
            {
                _Instance = FindObjectOfType<GameManager>();
            }
            return _Instance;
        }
    }

    #endregion



    public int trueCount = 0;
    public int falseCount = 0;

    public List<bool> successList;

    public GameObject cube;

    public GameObject canv;

    private void Awake()
    {
        successList = new List<bool>();
    }

    private void Update()
    {

        if (successList.Count > 0)
        {
            Debug.Log("Hello");
            RpcUpdateCube();
            RpcUpdateUI();
        }
    }

    [ClientRpc]
    void RpcUpdateCube()
    {
        cube.GetComponent<MeshRenderer>().material.color = Color.blue;

    }


    [ClientRpc]
    void RpcUpdateUI()
    {
        Text trueCou = canv.transform.GetChild(0).GetChild(1).GetComponent<Text>();
        Text falseCou = canv.transform.GetChild(0).GetChild(2).GetComponent<Text>();

        trueCou.text = trueCount.ToString();
        falseCou.text = falseCount.ToString();
    }
}


