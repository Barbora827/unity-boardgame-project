using UnityEngine;

public class CameraPlayer : MonoBehaviour {

    public static GameObject player1, player2;

    // Update is called once per frame
    void Update () {
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");
        if (player1.GetComponent<FollowThePath>().moveAllowed == true){
            transform.position = player1.transform.position + new Vector3(0, 2, -20);
        }
        if (player2.GetComponent<FollowThePath>().moveAllowed == true){
            transform.position = player2.transform.position + new Vector3(0, 2, -20);
        }
        
        
    }
}