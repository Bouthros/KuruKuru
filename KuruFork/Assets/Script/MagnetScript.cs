using UnityEngine;
using System.Collections;
 
 public class MagnetScript : MonoBehaviour
{

    public GameObject attractedTo;
    public float strengthOfAttraction = 5.0f;

    private Rigidbody2D rg2d;
    private float speed = 10.0f;
    private Vector2 target;

    void Start()
    {
        rg2d = this.GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        Vector3 direction = attractedTo.transform.position - transform.position;
        //rg2d.AddForce(strengthOfAttraction * direction

        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, direction, -step);
    }
}