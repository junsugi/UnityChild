using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float cameraIntervalY;

    GameObject player;
    Vector3 playerPos;

    private void Awake() {
        transform.position = new Vector3(0, 0, -20);
    }

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = this.player.transform.position;

        if (playerPos.y <= 0) {
            transform.position = new Vector3(0, 0, -20);
        }
        else {
            transform.position = new Vector3(
            transform.position.x, playerPos.y, transform.position.z);
        }
        
    }
}