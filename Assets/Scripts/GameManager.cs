using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioClip pauseSound;
    private AudioSource audioSource;
    private Transform canvasTransform;
    private GameObject panel;
    private GameObject buttonDescriptions;
    private Text tabMsgTxt;
    private bool isPause = false;

    // Start is called before the first frame update
    void Start()
    {
        canvasTransform = GameObject.Find("Canvas").GetComponent<Transform>();
        panel = canvasTransform.Find("Panel").gameObject;
        buttonDescriptions = canvasTransform.Find("button_descriptions").gameObject;
        tabMsgTxt = canvasTransform.Find("tab_msg").GetComponent<Text>();
        audioSource = GetComponent<AudioSource>();
        Resume();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) {
            isPause = !isPause;
            if (isPause) {
                Pause();
            } else {
                Resume();
            }
        }
    }

    void Pause()
    {
        audioSource.PlayOneShot(pauseSound);
        panel.SetActive(true);
        buttonDescriptions.SetActive(true);
        tabMsgTxt.text = "- Back to Game";
        Time.timeScale = 0f;
    }

    void Resume()
    {
        panel.SetActive(false);
        buttonDescriptions.SetActive(false);
        tabMsgTxt.text = "- How to Play";
        Time.timeScale = 1f;
    }
}
