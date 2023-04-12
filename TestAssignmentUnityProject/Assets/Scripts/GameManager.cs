using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject pause;
    public AudioClip pauseSound;
    public AudioClip resumeSound;

    private AudioSource playerSource;
    private PlayerShootController player;



    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }

        Destroy(gameObject);
    }

    private void Start()
    {
        player = FindObjectOfType<PlayerShootController>();
        playerSource = FindObjectOfType<AudioSource>();
    }

    public void Play()
    {
        pause.SetActive(false);
        playerSource.PlayOneShot(resumeSound);

        Time.timeScale = 1.0f;
        player.enabled = true;
    }

    public void Pause()
    {
        pause.SetActive(true);
        playerSource.PlayOneShot(pauseSound);

        Time.timeScale = 0.0f;
        player.enabled = false;
    }

    public void Quit()
    {
        Application.Quit();
    }

}
