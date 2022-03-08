using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

// written by Alice Hua
// Instantiate players for networked multiplayer

public class SpawnPlayers : MonoBehaviour
{

    // position of player 1
    [SerializeField] private float p1PosX;
    [SerializeField] private float p1PosY;

    // position of player 2
    [SerializeField] private float p2PosX;
    [SerializeField] private float p2PosY;

    [SerializeField] private GameObject p1Prefab;
    [SerializeField] private GameObject p2Prefab;

    public GameObject p1;
    public GameObject p2;

    private GameObject cam;
    private MultipleTargetCamera mtc;

    // Instantiates both players
    void Start()
    {
        cam = GameObject.Find("Main Camera");
        mtc = cam.GetComponent<MultipleTargetCamera>();

        p1 = PhotonNetwork.Instantiate(p1Prefab.name,new Vector2(p1PosX,p1PosY), Quaternion.identity);
        // p2 = PhotonNetwork.Instantiate(p2Prefab.name,new Vector2(p2PosX,p2PosY), Quaternion.identity);

        mtc.targets.Add(p1.transform);
        // mtc.targets.Add(p2.transform);
    }

}
