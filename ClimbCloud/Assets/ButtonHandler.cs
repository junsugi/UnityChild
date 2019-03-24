using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject cat;
    public PlayerController pController;

    bool LBDowned;
    bool RBDowned;
    // bool JBDowned;

    Transform catTransform;


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

    private void Awake() {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        catTransform = cat.GetComponent<Transform>();
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
        if ((pController.rigid2D.velocity.x == 0 && pController.rigid2D.velocity.y == 0)) {
            pController.animator.SetTrigger("Idle");
        }
    }

    void LHandler() {
        pController.key = -1;

        float speedx = Mathf.Abs(pController.rigid2D.velocity.x);

        if (speedx < pController.maxWalkSpeed) {
            pController.rigid2D.AddForce(transform.right * pController.key * pController.walkForce);
        }

        if (pController.key != 0) {
            catTransform.localScale = new Vector3(pController.key, 1, 1);
        }

        if (pController.rigid2D.velocity.y == 0) {
            pController.animator.speed = speedx / 2.0f;
            pController.animator.SetTrigger("Walk");
        }
        else {
            pController.animator.speed = 1.0f;
        }
    }

    void RHandler() {
        pController.key = 1;

        float speedx = Mathf.Abs(pController.rigid2D.velocity.x);

        if (speedx < pController.maxWalkSpeed) {
            pController.rigid2D.AddForce(transform.right * pController.key * pController.walkForce);
        }

        if (pController.key != 0) {
            catTransform.localScale = new Vector3(pController.key, 1, 1);
        }

        if (pController.rigid2D.velocity.y == 0) {
            pController.animator.speed = speedx / 2.0f;
            pController.animator.SetTrigger("Walk");
        }
        else {
            pController.animator.speed = 1.0f;
        }
    }

    public void JumpHandler() {
        if ( /*Input.GetMouseButtonDown(0) && */ pController.rigid2D.velocity.y == 0) {
            pController.animator.SetTrigger("JumpTrigger");
            pController.rigid2D.AddForce(transform.up * pController.jumpForce);
        }
    }
}
