using UnityEngine;

public class CameraPlayer : MonoBehaviour {

    public static GameObject player1, player2;

    // Update once per frame
    void Update () {

        // Find the players
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");

        // Follow whichever player is currently moving
        if (player1.GetComponent<FollowThePath>().moveAllowed == true){
            transform.position = player1.transform.position + new Vector3(0, 2, -5);
        }
        if (player2.GetComponent<FollowThePath>().moveAllowed == true){
            transform.position = player2.transform.position + new Vector3(0, 2, -5);
        }
        
        
    }
}