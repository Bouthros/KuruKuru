using UnityEngine;
using System.Collections;

//Adding this allows us to access members of the UI namespace including Text.
using UnityEngine.UI;

public class CompletePlayerController : MonoBehaviour {

	public float speed;				//Floating point variable to store the player's movement speed.
	//public Text countText;			//Store a reference to the UI Text component which will display the number of pickups collected.
	//public Text winText;            //Store a reference to the UI Text component which will display the 'You win' message.

    public Text countColisionText;
    public Text lostText;

    private Rigidbody2D rb2d;		//Store a reference to the Rigidbody2D component required to use 2D Physics.
	private int count;				//Integer to store the number of pickups collected so far.
    private int rotation;

	// Use this for initialization
	void Start()
    {
        rotation = 1;
        speed = 100;

        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D>();

        //Initialize count to zero.
        count = 0;

        //Initialze winText to a blank string since we haven't won yet at beginning.
        countColisionText.text = "";
        SetColisionText();

        lostText.text = "";

    }

    private void SetColisionText()
    {
        countColisionText.text = "Count Collisions: " + count.ToString();
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
	{
        transform.Rotate(Vector3.forward, rotation * speed * Time.deltaTime);

        //transform.Rotate(0, 0, speed * Time.deltaTime); //rotates 50 degrees per second around z axis

        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis("Horizontal");

        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxis("Vertical");

        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        rb2d.AddForce(movement * 0.5f, ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (!collision.collider.gameObject.CompareTag("Vortex") && count < 3)
        {
            rotation = -rotation;
            count++;

            SetColisionText();
        }

        if (!collision.collider.gameObject.CompareTag("Vortex") && count < 3)

            //}
            /*else*/
            if (count == 3)
        {
            lostText.text = "You died!";
            transform.Rotate(Vector3.zero);

        }
    }

    //OnTriggerEnter2D is called whenever this object overlaps with a trigger collider.
    void OnTriggerEnter2D(Collider2D other) 
	{
	}

}
