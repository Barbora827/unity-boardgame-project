using UnityEngine;
using System; 
public class FollowThePath : MonoBehaviour {

    public int a;

    // Arrays of start points and end points of snakes and ladders 
    // Those can be manually editer in the inspector, but don't. For the love of god. Don't touch it.

    // Entrances: 18, 21, 34, 56, 64, 88, 29, 36, 44, 53, 84, 87, 92, 100
    public int[] entrance = {};
    // Ends: 46, 41, 54, 66, 80, 94, 10, 8, 25, 33, 58, 55, 70, 2
    public int[] end = {};

    public Transform[] waypoints;

    [SerializeField]
    private float moveSpeed = 1f;

    [HideInInspector]
    public int waypointIndex = 0;

    public bool moveAllowed = false;

    

	// Initialization
	private void Start () {
        
        // Move the players to the start position
        transform.position = waypoints[waypointIndex].transform.position;
        
	}
	
	// Update once per frame
	private void Update () {
        
        // If player is allowed to move, he will (¬‿¬)
        if (moveAllowed){
            Move();
        }
            
            
	}

    private void Move(){
       
        // If the destination hasn't been reached yet, move the player 
        if (waypointIndex <= waypoints.Length - 1){
            
            transform.position = Vector2.MoveTowards(transform.position,
            waypoints[waypointIndex].transform.position,
            moveSpeed * Time.deltaTime);
            
            // Add 1 to the waypointIndex count
            if (transform.position == waypoints[waypointIndex].transform.position){
                
                waypointIndex += 1;
            }

            print(waypointIndex);
            
        }
    }

    // Check if the player's destination is a snake or a ladder
    
    public void SnakesnLadders(){

        // Check if the waypoint belongs in the "entrance" array, hence it has an index of the array starting from 0 
        a = Array.IndexOf(entrance, waypointIndex);

        // If the waypoint belongs in the "entrance" array, change waypoint (destination) to correspond to the "entrance"
        // All corresponding "entrance" and "end" waypoints have the same index in their respective arrays
        if(a > -1 ){
            waypointIndex = end[a];

            // Move player to the new waypoint
            transform.position = waypoints[waypointIndex - 1].transform.position;
            
            //Array indexes 6+ are snakes - play the slip sound
            if(a >= 6){
            FindObjectOfType<AudioManager>().Play("SnakeSlip");
            print("Slipped");
            }

            //Array indexes < 6 are ladders - play the ladder sound
            if(a > -1 && a < 6){
            FindObjectOfType<AudioManager>().Play("Ladder");
            print("Ladder!");
            }   
        }
        
    }
    
}
