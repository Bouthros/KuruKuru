using UnityEngine;
using System.Collections;
 
 public class MagnetScript : MonoBehaviour
{

    public GameObject attractedTo;
    public float strengthOfAttraction = 5.0f;
    public float maxRange = 10;
    private Rigidbody2D rg2d;
    private float speed = 10.0f;
    private Vector2 target;

    void Start()
    {
        rg2d = this.GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        var heading = attractedTo.transform.position - transform.position;
        if (heading.sqrMagnitude < maxRange * maxRange)
        {
            //rg2d.((attractedTo.transform.position - transform.position).normalized * strengthOfAttraction);
            // The step size is equal to speed times frame time.
            float step = speed * Time.deltaTime;

            // Move our position a step closer to the target.
            transform.position = Vector3.MoveTowards(transform.position, attractedTo.transform.position, step);
        }


        //Vector3 direction = attractedTo.transform.position - transform.position;
        ////rg2d.AddForce(strengthOfAttraction * direction

        //float step = speed * Time.deltaTime;
        //transform.position = Vector2.MoveTowards(transform.position, direction, -step);
    }

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, maxRange);
    }
}