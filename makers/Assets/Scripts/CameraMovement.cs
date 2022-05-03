using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public Vector3 init_offset;
    public float smooth = 3f;
    public bool followActive = true;
    // Start is called before the first frame update
    void Start()
    {
        init_offset = offset;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target.position.x < 0)
        {
            followActive = false;
            //transform.position = new Vector3(0, transform.position.y, transform.position.z);
        }
        else if (target.position.x >= 0)
        {
            followActive = true;
        }


        if (followActive)
            transform.position = new Vector3(Vector3.Lerp(transform.position, target.position + offset, Time.deltaTime * smooth).x, transform.position.y, transform.position.z);
    }

    public void InitFollowCamera(Transform playerPos)
    {
        target = playerPos;
        transform.position = new Vector3(transform.position.x, (target.position + offset).y, (target.position + offset).z);
    }

}
