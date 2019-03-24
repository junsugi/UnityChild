using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContorller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void LButtonDown() {
        transform.Translate(-2, 0, 0);
    }
    public void RButtonDown() {
        transform.Translate(2, 0, 0);
    }
}
