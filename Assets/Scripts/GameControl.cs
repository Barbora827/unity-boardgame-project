using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {

    private static GameObject whoWinsText, player1MoveText, player2MoveText;

    private static GameObject player1, player2;

    public static int diceSideThrown = 0;
    public static int player1StartWaypoint = 0;
    public static int player2StartWaypoint = 0;

    public static bool gameOver = false;

    // Use this for initialization
    void Start () {
        gameOver = false;
        player1MoveText = GameObject.Find("Player1MoveText");
        player2MoveText = GameObject.Find("Player2MoveText");

        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");

        player1.GetComponent<FollowThePath>().moveAllowed = false;
        player2.GetComponent<FollowThePath>().moveAllowed = false;

        player1MoveText.gameObject.SetActive(true);
        player2MoveText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (player1.GetComponent<FollowThePath>().waypointIndex > 
            player1StartWaypoint + diceSideThrown)
        {
            player1.GetComponent<FollowThePath>().SnakesnLadders();
            player1.GetComponent<FollowThePath>().moveAllowed = false;
            player1MoveText.gameObject.SetActive(false);
            FindObjectOfType<AudioManager>().Stop("BoinkMove");
            player2MoveText.gameObject.SetActive(true);
            player1StartWaypoint = player1.GetComponent<FollowThePath>().waypointIndex - 1;
            
        }

        if (player2.GetComponent<FollowThePath>().waypointIndex >
            player2StartWaypoint + diceSideThrown)
        {
            player2.GetComponent<FollowThePath>().SnakesnLadders();
            player2.GetComponent<FollowThePath>().moveAllowed = false;
            player2MoveText.gameObject.SetActive(false);
            FindObjectOfType<AudioManager>().Stop("BoinkMove");
            player1MoveText.gameObject.SetActive(true);
            player2StartWaypoint = player2.GetComponent<FollowThePath>().waypointIndex - 1;
        }

        if (player1.GetComponent<FollowThePath>().waypointIndex == 
            player1.GetComponent<FollowThePath>().waypoints.Length)
        {
            SceneManager.LoadScene("Win1Scene");
            gameOver = true;
            
        }

        if (player2.GetComponent<FollowThePath>().waypointIndex ==
            player2.GetComponent<FollowThePath>().waypoints.Length)
        {
            player1MoveText.gameObject.SetActive(false);
            player2MoveText.gameObject.SetActive(false);
            SceneManager.LoadScene("Win2Scene");
            gameOver = true;
            
        }
    }

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
