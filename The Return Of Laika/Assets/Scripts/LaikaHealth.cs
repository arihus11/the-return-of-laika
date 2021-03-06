using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LaikaHealth : MonoBehaviour
{
    public static int health = 8;
    private bool isWaiting = false;
    public static bool gameOver;
    private Rigidbody2D rb;
    Vector2 startDirection;
    float timeStamp;
    private bool doOnce, doOnce2;
    public static bool movePlanets;

    [Header("Health Display")]
    public GameObject healthSystemCanvas;
    public Sprite fullHealthPointSprite;
    public Sprite emptyHealthPointSprite;
    private Transform healthSystem;
    private bool oneMusic;
    private AssembleShipPart assembleShipPartScript;


    // Start is called before the first frame update
    void Start()
    {
        movePlanets = false;
        GameObject.Find("MeteorMusic").gameObject.GetComponent<AudioSource>().Stop();
        oneMusic = false;
        PlayerPrefs.SetInt("FirstMeteorShowerPref", 0);
        doOnce = false;
        doOnce2 = false;
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        gameOver = false;
        setHealth(8);
        healthSystem = healthSystemCanvas.transform;
        assembleShipPartScript = this.gameObject.GetComponent<AssembleShipPart>();
    }

    // Update is called once per frame
    void Update()
    {
        updateHealthDisplay();
        if (health == 0)
        {
            if (!oneMusic)
            {
                oneMusic = true;
                AssembleShipPart.numberOfPartsAssambled = 0;
                GrabShipPart.alredyGrabbedParts.Clear();
                GameObject.Find("MeteorMusic").gameObject.GetComponent<AudioSource>().Stop();
                MeteorShowerSpawner.meteorMusicPlaying = false;
                if (!(GameObject.Find("Music").gameObject.GetComponent<AudioSource>().isPlaying))
                {
                    GameObject.Find("Music").gameObject.GetComponent<AudioSource>().Play();
                }

            }
            PlayerPrefs.SetInt("FirstMeteorShowerPref", 0);
            GrabShipPart.firstGrabEver = false;
            GameObject.Find("JetpackSoundManager").gameObject.GetComponent<AudioSource>().enabled = false;
            gameOver = true;
            this.gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            GameObject.FindGameObjectWithTag("gameOverCanvas").gameObject.GetComponent<Animator>().Play("DisplayGameOverText1");
            Invoke("reverseDisplayGameOver", 4.5f);
            assembleShipPartScript.Invoke("handleDeath", 6.5f);
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Glow")
        {
            if (gameOver == false)
            {
                if (isWaiting == false)
                {
                    SoundManagerScript.PlaySound("damage");
                    setHealth(health - 1);
                    showWhenHurt();
                    Debug.Log("LAIKA HEALTH: " + health.ToString());
                    StartCoroutine(DamageForTwoSeconds());
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "powerUp")
        {
            if (gameOver == false)
            {
                if (health == 8)
                {
                    GameObject.Find("PowerUpMessageContainer").gameObject.GetComponent<Animator>().Play("PowerUpNotSick", -1, 0f);
                }
                else if (health < 8)
                {
                    SoundManagerScript.PlaySound("eat");
                    GameObject.Find("PowerUpMessageContainer").gameObject.GetComponent<Animator>().Play("PowerUpSick", -1, 0f);
                    setHealth(health + 1);
                    Debug.Log("LAIKA HEALTH: " + health.ToString());
                    Destroy(col.gameObject);
                }
            }
        }
    }

    IEnumerator DamageForTwoSeconds()
    {
        isWaiting = true;
        yield return new WaitForSecondsRealtime(2);
        isWaiting = false;
    }

    public void showWhenHurt()
    {
        GameObject.FindGameObjectWithTag("blood").gameObject.GetComponent<Animator>().Play("BloodAnim", -1, 0f);
        if (RandomAnimGenerator.randomNumber == 1)
        {

            GameObject.Find("HurtMessageContainer").gameObject.GetComponent<Animator>().Play("OuchDisplay", -1, 0f);
            RandomAnimGenerator.calculateRandomNumber();
        }
        else
        {
            GameObject.Find("HurtMessageContainer").gameObject.GetComponent<Animator>().Play("ThatHurtsDisplay", -1, 0f);
            RandomAnimGenerator.calculateRandomNumber();
        }
    }

    public void reverseDisplayGameOver()
    {
        GameObject.FindGameObjectWithTag("gameOverCanvas").gameObject.GetComponent<Animator>().Play("DisplayGameOverText1Reverse");
        setHealth(8);
        Invoke("laikaDisapear", 1.3f);
        Invoke("moveLaikaBackInTime", 2f);
    }

    public void moveLaikaBackInTime()
    {
        if (doOnce2 == false)
        {
            this.gameObject.transform.position = GameObject.FindGameObjectWithTag("startPosition").gameObject.transform.position;
            movePlanets = true;
            Invoke("makeEverythingNormal", 2f);
            doOnce2 = true;
        }
    }

    public void laikaDisapear()
    {
        if (doOnce == false)
        {
            SoundManagerScript.PlaySound("teleport");
            this.gameObject.GetComponent<Animator>().Play("LaikaDisapear");
            doOnce = true;
        }
    }

    public void makeEverythingNormal()
    {
        gameOver = false;
        oneMusic = false;
        BlackHoleMagnet.flyToHole = false;
        MeteorShowerSpawner.destroyMeteorsGameOver = false;
        this.gameObject.GetComponent<Animator>().Play("LaikaFloatInSpace");
        this.gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
        GameObject.Find("JetpackSoundManager").gameObject.GetComponent<AudioSource>().enabled = true;
        movePlanets = false;
        Invoke("changeSwitches", 4f);
    }

    public void changeSwitches()
    {
        doOnce = false;
        doOnce2 = false;
    }

    private void setHealth(int newHealth)
    {
        health = newHealth;
    }

    public void updateHealthDisplay()
    {
        for (int i = 1; i <= healthSystem.childCount; i++)
        {
            healthSystem
                .GetChild(i - 1)
                .Find("Sprite")
                .GetComponent<SpriteRenderer>()
                .sprite = i <= health ? fullHealthPointSprite : emptyHealthPointSprite;
        }
    }
}
