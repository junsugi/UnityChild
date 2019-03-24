using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public float jumpForceTest;

    Animator animator;
    Rigidbody2D rigid2D;
    float walkForce = 1.0f;
    float maxWalkSpeed = 2.0f;
    float jumpForce;
    int key = 0;

    private void Awake() {
        jumpForce = jumpForceTest;
    }

    void Start() {
        this.animator = GetComponent<Animator>();
        this.rigid2D = GetComponent<Rigidbody2D>();
    }

    void Update() {
        //캐릭터의 이미지 반전
        if (this.key != 0) {
            transform.localScale = new Vector3(this.key, 1, 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        SceneManager.LoadScene("MenuScene");
    }

    public Rigidbody2D getRigidBody() { return this.rigid2D;}
    public Animator getAnimator() { return this.animator; }
    public int getKey(){ return this.key; }
    public int setKey(int key){ return this.key = key; }
    public float getWalkForce(){ return this.walkForce; }
    public float getJumpForce() { return this.jumpForce; }
    public float getMaxWalkSpeed(){ return this.maxWalkSpeed; }
}
