using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AfterMoving : MonoBehaviour
{
    public GameObject dialogueBox;
    public GameObject dialogueBox2;
    public GameObject textBox2;
    public GameObject explosion;

    public GameObject spaceship;
    public Sprite brokenShip;
    private bool oneFlyOut;
    private bool oneRumble;

    private bool oneActive;

    // Start is called before the first frame update
    void Start()
    {
        oneActive = false;
        oneRumble = false;
        oneFlyOut = false;
        textBox2.SetActive(false);
        dialogueBox2.SetActive(false);
        explosion.SetActive(false);
        this.gameObject.GetComponent<Animator>().enabled = false;
        //    Invoke("preRumbleActions", 61.3f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Invoke("stopTheMusic", 3f);
            try
            {
                GameObject.FindGameObjectWithTag("pressKeyToSkip").gameObject.SetActive(false);
            }
            catch (System.NullReferenceException)
            {
                Debug.Log("Avoid null reference");
            }
            closeCutscene();
        }
        if (RumbleText.rumbleActive == true && !oneActive)
        {
            oneActive = true;
            RumbleText.rumbleActive = false;
            preRumbleActions();
        }
    }

    public void stopTheMusic()
    {
        GameObject.Find("Music").gameObject.GetComponent<AudioSource>().Stop();
        GameObject.Find("SoundManager").gameObject.GetComponent<AudioSource>().Stop();
        GameObject.Find("ShipSoundManager").gameObject.GetComponent<AudioSource>().Stop();
    }

    public void preRumbleActions()
    {
        this.gameObject.GetComponent<CameraFollowPlayerScript>().enabled = false;
        Invoke("rumbleActions", 0.2f);
    }

    public void rumbleActions()
    {

        GameObject.Find("Music").gameObject.GetComponent<AudioSource>().Pause();

        if (!oneRumble)
        {
            SoundManagerScript.PlaySound("cutscene_rumble");
        }
        dialogueBox2.SetActive(true);
        dialogueBox.SetActive(false);
        // this.gameObject.GetComponent<Animator>().enabled = true;
        // this.gameObject.GetComponent<Animator>().Play("ShipShaking");
        spaceship.GetComponent<Animator>().Play("ShipShake");
        Invoke("deactivateShaking", 7f);

    }

    public void deactivateShaking()
    {
        this.gameObject.GetComponent<Animator>().enabled = false;
        Invoke("explode", 2.7f);
    }

    public void explode()
    {
        explosion.SetActive(true);
        GameObject.FindGameObjectWithTag("shipRawSprite").gameObject.GetComponent<SpriteRenderer>().sprite = brokenShip;
        GameObject.FindGameObjectWithTag("realShip").gameObject.transform.GetChild(1).gameObject.SetActive(true);
        blowUpSound();
        Invoke("laikaFlyOut", 0.1f);
        Invoke("beginTypingAgain", 4.5f);
    }

    public void laikaFlyOut()
    {
        spaceship.GetComponent<Animator>().Play("LaikaBlownUp");
        GameObject.FindGameObjectWithTag("shipRawSprite").gameObject.GetComponent<Animator>().Play("ShipFlyAway");

    }

    public void blowUpSound()
    {
        if (!oneFlyOut)
        {
            SoundManagerScript.StopSound();
            SoundManagerScript.PlaySound("ship_explosion");
            oneFlyOut = true;
        }
    }


    public void beginTypingAgain()
    {
        textBox2.SetActive(true);
        Invoke("closeLastBox", 13.35f);
        Invoke("closeCutscene", 11f);
    }

    public void closeCutscene()
    {
        GameObject.FindGameObjectWithTag("cosingPanel").gameObject.GetComponent<Animator>().Play("closeCutscene1");
        Invoke("stopTheMusic", 3f);
        Invoke("changeToMain", 4.0f);
    }

    public void changeToMain()
    {
        SceneManager.LoadScene("Chapter1Text");
    }

    public void closeLastBox()
    {
        GameObject.Find("DialogueBox2").gameObject.GetComponent<Animator>().Play("closeLastDialogueBox");
    }
}
