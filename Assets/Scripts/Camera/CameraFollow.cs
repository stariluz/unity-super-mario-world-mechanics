using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    GameObject player;
    float pX,pY, pZ=-10;
    // Start is called before the first frame update
    void Start()
    {
        player=GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        pX=player.transform.position.x;
        pY=player.transform.position.y;
        gameObject.transform.SetPositionAndRotation(new Vector3(pX,pY,pZ), player.transform.rotation);
    }
}
