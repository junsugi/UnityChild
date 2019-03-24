using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

    public Transform player;
    public PlayerController pController;

    bool LBDowned;
    bool RBDowned;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (LBDowned) {
            LHandler();
        }
        else if (RBDowned) {
            RHandler();
        }
        if ((pController.getRigidBody().velocity.x == 0 && pController.getRigidBody().velocity.y == 0)) {
            pController.getAnimator().SetTrigger("Idle");
        }
    }

    public void OnPointerDown(PointerEventData eventData) {

        if (this.gameObject.name == "LButton") {
            LBDowned = true;
            RBDowned = false;
        }
        else if (this.gameObject.name == "RButton") {
            RBDowned = true;
            LBDowned = false;
        }

    }

    public void OnPointerUp(PointerEventData eventData) {
        LBDowned = false;
        RBDowned = false;
    }

    void LHandler() {
        pController.setKey(-1);

        float speedx = Mathf.Abs(pController.getRigidBody().velocity.x);

        if (speedx < pController.getMaxWalkSpeed()) {
            pController.getRigidBody().AddForce(transform.right * pController.getKey() * pController.getWalkForce());
        }

        if (pController.getKey() != 0) {
            player.localScale = new Vector3(pController.getKey(), 1, 1);
        }

        if (pController.getRigidBody().velocity.y == 0) {
            pController.getAnimator().speed = speedx / 2.0f;
            pController.getAnimator().SetTrigger("Idle");
        }
        else {
            pController.getAnimator().speed = 1.0f;
        }
    }

    void RHandler() {
        pController.setKey(1);

        float speedx = Mathf.Abs(pController.getRigidBody().velocity.x);

        if (speedx < pController.getMaxWalkSpeed()) {
            pController.getRigidBody().AddForce(transform.right * pController.getKey() * pController.getWalkForce());
        }

        if (pController.getKey() != 0) {
            player.localScale = new Vector3(pController.getKey(), 1, 1);
        }

        if (pController.getRigidBody().velocity.y == 0) {
            pController.getAnimator().speed = speedx / 2.0f;
            pController.getAnimator().SetTrigger("Idle");
        }
        else {
            pController.getAnimator().speed = 1.0f;
        }
    }

    public void JumpHandler() {
         pController.getAnimator().SetTrigger("Fly");
         pController.getRigidBody().AddForce(transform.up * pController.getJumpForce());
    }
}
