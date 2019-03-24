using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialController : MonoBehaviour
{
    public GameObject tutorial1;
    public GameObject tutorial2;
    public GameObject getStart;
    public GameObject button;

    void Start()
    {
        tutorial2.SetActive(false);
        getStart.SetActive(false);
        button.SetActive(false);
    }

    void Update()
    {      
        if (Input.GetMouseButtonDown(0)) {
            tutorial1.SetActive(false);
            tutorial2.SetActive(true);
            getStart.SetActive(true);
            button.SetActive(true);
        }
    }

    public void Play() {
        SceneManager.LoadScene("GameScene");
    }
}
