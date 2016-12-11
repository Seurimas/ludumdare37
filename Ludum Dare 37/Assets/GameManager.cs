using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager instance = null;
    public AdventurerManager adventurerManager;
    public ResourceManager resourceManager;
    public GameObject bahamut;
    public AudioClip mainTheme;
    public AudioClip gameOver;
    public AudioSource musicSource;
    private bool gameActive = false;
    private float gameEndDuration = 5f;
    private float gameEndProgress = 0;

    public void setDragon(GameObject dragon)
    {
        bahamut = dragon;
        gameActive = true;
        adventurerManager.gameObject.SetActive(gameActive);
        resourceManager.gameObject.SetActive(gameActive);
        musicSource.Stop();
        musicSource.loop = true;
        musicSource.clip = mainTheme;
        musicSource.Play();
    }

    // Use this for initialization

    void Awake ()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            DestroyObject(this);
        DontDestroyOnLoad(this);
        adventurerManager = GetComponent<AdventurerManager>();
        resourceManager = GetComponent<ResourceManager>();
        musicSource = GetComponentInChildren<AudioSource>();
    }
	void Start () {
    }
	void Update () {
        if (gameActive && bahamut == null)
        {
            gameActive = false;
            gameEndProgress = 0;
            musicSource.Stop();
            musicSource.loop = false;
            musicSource.clip = gameOver;
            musicSource.Play();
        } else if (!gameActive && gameEndProgress < gameEndDuration)
        {
            gameEndProgress += Time.deltaTime;
        } else if (!gameActive && gameEndProgress >= gameEndDuration)
        {
            if (SceneManager.GetActiveScene().name == "start")
                SceneManager.LoadScene("mainMenu");
        }
	}
}
