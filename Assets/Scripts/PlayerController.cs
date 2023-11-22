using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //movement variables
    public int speed = 5;
    public int rotationSpeed = 150;

    //game objects 
    public GameObject player;
    public GameOverScreen GameOverScreen;

    public Text pressButton; //prompt to press button

    public static PlayerController instance;


    public bool pickingUp = false;
    public bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        instance = this; //set instance 
        isDead = true; //set alive state

    }

    // Update is called once per frame
    void Update()
    {
        //if the player is not dead
        if (isDead == false)
        {
            //all key inputs + animation playing on E W S and no key press
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
                GetComponent<Animator>().Play("Old Man Walk");
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.back * speed * Time.deltaTime);
                player.GetComponent<Animator>().Play("Old Man Walk");
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(-Vector3.up * rotationSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                player.GetComponent<Animator>().Play("Picking Up");
                pressButton.text = "";
            }

        }

        



    }

    //On trigger enter with Wolfs
    void OnTriggerEnter(Collider other)
    {
        //kill player if hit by wolf
        if (other.gameObject.CompareTag("Wolf"))
        {
            GameOver();
            player.GetComponent<Animator>().Play("Fall Flat"); //play falling animation
        }
        //stop wolfs if the player is safe
        if (other.gameObject.CompareTag("Save") && PointCounter.instance.Score() > 0)
        {
            WolfAI.instance.stopWolf();
        }
        //if the object is trash prompt user for pick up keybind
        if (other.CompareTag("Trash"))
        {
            pressButton.text = "Press E to pick up"; 

        }

    }

    //if left the trigger stop the prompt
    private void OnTriggerExit(Collider other)
    {

        pressButton.text = "";
    }

    //kill the player
    void GameOver()
    {
        isDead = true;
        GameOverScreen.Setup(PointCounter.instance.Score());
    }


}