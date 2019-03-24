using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    [HideInInspector] public Rigidbody2D rigid2D;
    [HideInInspector] public Animator animator;
    [HideInInspector] public float jumpForce = 780.0f;
    [HideInInspector] public float walkForce = 30.0f;
    [HideInInspector] public float maxWalkSpeed = 2.0f;
    [HideInInspector] public float threshold = 0.2f;
    [HideInInspector] public int key = 0;

    float timer;

    void Start() {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }

    void Update() {
        if (transform.position.y < -10) {
            SceneManager.LoadScene("GameScene");
        }
        timer = Time.deltaTime;
        Debug.Log(timer);
    }

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("골");
        SceneManager.LoadScene("ClearScene");
    }
}
