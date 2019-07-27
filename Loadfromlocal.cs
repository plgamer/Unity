using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class Loadfromlocal : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Loadplayership());
    }
    private IEnumerator Loadplayership()
    {


        AssetBundle ps = AssetBundle.LoadFromFile("D:/unityfiles/AssetBundles/model_ab/playership.ab");
        GameObject obj = ps.LoadAsset<GameObject>("vehicle_playerShip.FBX");
        Instantiate(obj);
        yield return 0;
    }

}
