using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {

    private static GameObject player1Icon, player2Icon, player1MoveText, player2MoveText;

    private static GameObject player1, player2;

    public static int diceSideThrown = 0;
    public static int player1StartWaypoint = 0;
    public static int player2StartWaypoint = 0;

    public static bool gameOver = false;

    // Initialization
    void Start () {
        gameOver = false;

        // Find all the objects we'll be interacting with
        player1MoveText = GameObject.Find("Player1MoveText");
        player2MoveText = GameObject.Find("Player2MoveText");

        player1Icon = GameObject.Find("Player1Icon");
        player2Icon = GameObject.Find("Player2Icon");

        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");

        // Nobody is allowed to move at the start
        player1.GetComponent<FollowThePath>().moveAllowed = false;
        player2.GetComponent<FollowThePath>().moveAllowed = false;

        // Player 1 starts - set Player 2 to inactive
        player1MoveText.gameObject.SetActive(true);
        player1Icon.gameObject.SetActive(true);
        player2MoveText.gameObject.SetActive(false);
        player2Icon.gameObject.SetActive(false);
    }

    // Update called once per frame
    void Update()
    {   
        // If player reached his destination (f.e. rolled 3 and moved 3 squares)
        if (player1.GetComponent<FollowThePath>().waypointIndex > 
            player1StartWaypoint + diceSideThrown){

            // Check if the destination is a ladder or a snake
            player1.GetComponent<FollowThePath>().SnakesnLadders();

            // Switch players => disallow active player from moving, set him to inactive,
            // stop the sound effect, set inactive to active
            player1.GetComponent<FollowThePath>().moveAllowed = false;
            player1MoveText.gameObject.SetActive(false);
            player1Icon.gameObject.SetActive(false);
            FindObjectOfType<AudioManager>().Stop("BoinkMove");

            player2MoveText.gameObject.SetActive(true);
            player2Icon.gameObject.SetActive(true);
            player1StartWaypoint = player1.GetComponent<FollowThePath>().waypointIndex - 1;
        }

        // Repeat for Player 2
        if (player2.GetComponent<FollowThePath>().waypointIndex >
            player2StartWaypoint + diceSideThrown){

            player2.GetComponent<FollowThePath>().SnakesnLadders();
            player2.GetComponent<FollowThePath>().moveAllowed = false;
            player2MoveText.gameObject.SetActive(false);
            player2Icon.gameObject.SetActive(false);
            FindObjectOfType<AudioManager>().Stop("BoinkMove");

            player1MoveText.gameObject.SetActive(true);
            player1Icon.gameObject.SetActive(true);
            player2StartWaypoint = player2.GetComponent<FollowThePath>().waypointIndex - 1;
        }

        // If player's destination equals to the last waypoint on board, win the game
        if (player1.GetComponent<FollowThePath>().waypointIndex == 
            player1.GetComponent<FollowThePath>().waypoints.Length){
            gameOver = true; 
            SceneManager.LoadScene("Win1Scene");
             
        }

        // Repeat for Player 2
        if (player2.GetComponent<FollowThePath>().waypointIndex ==
            player2.GetComponent<FollowThePath>().waypoints.Length){
            gameOver = true;     
            SceneManager.LoadScene("Win2Scene");
             
        }

        // Exit application on ESC
        if(Input.GetKeyDown(KeyCode.Escape)){
            
            Application.Quit();
        }
    }

    // Switch between players, play sound effect while they're moving
    public static void MovePlayer(int playerToMove)
    {
        switch (playerToMove) { 
            
            case 1:
                player1.GetComponent<FollowThePath>().moveAllowed = true;
                FindObjectOfType<AudioManager>().Play("BoinkMove");
                break;

            case 2:
                player2.GetComponent<FollowThePath>().moveAllowed = true;
                FindObjectOfType<AudioManager>().Play("BoinkMove");
                break;
        }
    }
}
