using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 20f;
    private Vector3 horizontalMovement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = new Vector3(0f, 0f, -Input.GetAxis("Horizontal"));

        transform.Rotate(horizontalMovement * rotationSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.Space))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.up) * 10f, Color.red);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector3.up), 10f);

            if (hit)
            {
                Debug.Log("You hit " + hit.collider.name);
                hit.transform.GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
    }
}
