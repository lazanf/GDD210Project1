using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollowsPlayer : MonoBehaviour {

    private Vector3 offset;
    public GameObject player;

    // Use this for initialization
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y > -10)
        {
            transform.position = player.transform.position + offset;
        }
    }
}