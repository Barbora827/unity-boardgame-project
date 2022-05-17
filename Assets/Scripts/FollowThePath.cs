using UnityEngine;
using System; 
public class FollowThePath : MonoBehaviour {

    public int a;
    public int[] entrance = {18, 21, 34, 56, 64, 88, 29, 36, 44, 53, 84, 87, 92, 100};
    public int[] end = {46, 41, 54, 66, 80, 94, 10, 8, 25, 33, 58, 55, 70, 2};

    public Transform[] waypoints;

    [SerializeField]
    private float moveSpeed = 1f;

    [HideInInspector]
    public int waypointIndex = 0;

    public bool moveAllowed = false;

    

	// Use this for initialization
	private void Start () {
        
        transform.position = waypoints[waypointIndex].transform.position;
        
	}
	
	// Update is called once per frame
	private void Update () {
        
        
        if (moveAllowed){
            Move();
        }
            
            
	}

    private void Move()
    {
       
        if (waypointIndex <= waypoints.Length - 1)
        {
            
            transform.position = Vector2.MoveTowards(transform.position,
            waypoints[waypointIndex].transform.position,
            moveSpeed * Time.deltaTime);
            

            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                
                waypointIndex += 1;
                
            }

            print(waypointIndex);
            
            
        }
     
    }

    public void SnakesnLadders(){
        a = Array.IndexOf(entrance, waypointIndex);
        if(a > -1 ){
            waypointIndex = end[a];
            transform.position = waypoints[waypointIndex - 1].transform.position;
            
            if(a >= 6){
            FindObjectOfType<AudioManager>().Play("SnakeSlip");
            print("Slipped");
            }
            if(a > -1 && a < 6){
            FindObjectOfType<AudioManager>().Play("Ladder");
            print("Ladder!");
            }   
        }
        
    }
    
}
