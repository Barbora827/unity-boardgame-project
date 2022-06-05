using System.Collections;
using UnityEngine;

public class Dice : MonoBehaviour {

    private Sprite[] diceSides;
    private SpriteRenderer rend;
    private int whosTurn = 1;
    private bool coroutineAllowed = true;

    private Vector3 lastAcceleration;
    private bool forceRequestSend = false;
    

	// Initialization
    // Initialize accelerometer, load all dice sides images to an array
	private void Start () {
        lastAcceleration = Input.acceleration;
        rend = GetComponent<SpriteRenderer>();
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");
        rend.sprite = diceSides[5];
        
        
	}

    void Update()
    {
        // Setup the acceleration for phone shake
        Vector3 currentAcceleration = Input.acceleration;
        Vector3 deltaAcceleration = lastAcceleration - currentAcceleration;
        lastAcceleration = currentAcceleration;

        float force = deltaAcceleration.magnitude;

        // If the phone is being shaked, the game isn't over and couroutine is allowed, roll the dice
        if(force > 1.0f && forceRequestSend == false) {
            forceRequestSend = true;
            if (!GameControl.gameOver && coroutineAllowed){
            StartCoroutine("RollTheDice");
            }
        }

        if(force < 0.01f) {
            forceRequestSend = false;
        }
    }

    // If the dice is clicked, the game isn't over and couroutine is allowed, roll the dice
    private void OnMouseDown(){   
        if (!GameControl.gameOver && coroutineAllowed)
            StartCoroutine("RollTheDice");
    }

    // Determine the dice
    private IEnumerator RollTheDice()
    {
        coroutineAllowed = false;
        int randomDiceSide = 0;

        // Cycle randomly through the dice sides for 20 frames(?) 
        FindObjectOfType<AudioManager>().Play("DiceShake");
        for (int i = 0; i <= 20; i++)
        {
            randomDiceSide = Random.Range(0, 6);
            rend.sprite = diceSides[randomDiceSide];
            yield return new WaitForSeconds(0.05f);
        }

        
        GameControl.diceSideThrown = randomDiceSide + 1;
        // Whoever is on turn will move
        if (whosTurn == 1){
            GameControl.MovePlayer(1);   
        } 
        else if (whosTurn == -1){
            GameControl.MovePlayer(2);
        }
        
        whosTurn *= -1;
        coroutineAllowed = true;
    }
}
