using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NewBehaviourScript : MonoBehaviourPunCallbacks
{
    int a = 0;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (a < 10)
        {
            var position = new Vector3(Random.Range(-3f, 3f), 1, Random.Range(-3f, 3f));
            PhotonNetwork.Instantiate("Avatar", position, Quaternion.identity);
            a++;
        }
    }
}
