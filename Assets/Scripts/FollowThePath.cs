using UnityEngine;
using System; 
public class FollowThePath : MonoBehaviour {

    public Transform[] waypoints;

    [SerializeField]
    private float moveSpeed = 1f;

    [HideInInspector]
    public int waypointIndex = 0;

    public bool moveAllowed = false;

    public int a;
    public int[] entrance = {2, 3, 4, 5, 6, 7};
    public int[] end = {10, 11, 12, 13, 14, 15};

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
        print("Entrance: " + entrance);
        a = Array.IndexOf(entrance, waypointIndex);
        if(a > -1 ){
            waypointIndex = end[a];
            transform.position = waypoints[waypointIndex].transform.position;
            print(a + " and " + waypointIndex);
            if(a > 3){
            FindObjectOfType<AudioManager>().Play("SnakeSlip");
            }
            if(a > -1 && a <= 3){
            FindObjectOfType<AudioManager>().Play("Ladder");
            }   
        }
        
    }
    
}
