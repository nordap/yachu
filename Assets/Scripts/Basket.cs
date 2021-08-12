using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    public float rotateSpeed = 1.0f;
    public bool trg = false;
    public bool rotateDone = false;

    public void BasketDrop()
    {
        Quaternion newRotation = Quaternion.AngleAxis(150f, Vector3.forward);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, .05f);
    }
    public void BasketPush()
    {
        Vector3 newPosition = new Vector3(20f, 15f, 0f);
        transform.position = Vector3.Lerp(transform.position, newPosition, .04f);

    }
    public void BasketUp()
    {
        Quaternion newRotation = Quaternion.AngleAxis(0.25f, Vector3.forward);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, .07f);
    }
    public void BasketPull()
    {
        Vector3 newPosition = new Vector3(45f, 15f, 0f);
        transform.position = Vector3.Lerp(transform.position, newPosition, .07f);

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Quaternion rot = transform.rotation;
        //rot.eulerAngles.z
        /*
        public float turnSpeed = 1.0f; //adjust this value to get a faster rotation speed.
        float rotation;
 
 
        if(Input.GetKeyDown (KeyCode.A))
        {        
             rotation = Input.GetAxis("Horizontal") * turnSpeed;
             transform.Rotate(transform.up, rotation);
        }
        */
        if (rot.eulerAngles.z == 0.0f && Input.GetKeyDown(KeyCode.Space))
            trg = true;
        if (rot.eulerAngles.z > 149.9f)
        {
            rotateDone = true;
        }
    }
    private void FixedUpdate()
    {
        Quaternion rot = transform.rotation;

        if (trg && !rotateDone)
        {
            BasketDrop();
            if(rot.eulerAngles.z > 30f)
                BasketPush();
        }
        if (rotateDone)
        {
            BasketPull();
            BasketUp();
        }
    }
}
