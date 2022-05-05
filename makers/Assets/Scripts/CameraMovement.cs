using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float smooth = 3f;

    public Vector2 mapSize;
    public Vector2 center;

    float height;
    float width;

    bool canMoveY=false;

    void Start()
    {
        height = Camera.main.orthographicSize;
        width = height * Screen.width / Screen.height;
        center = new Vector2(mapSize.x - height, mapSize.y - height); //mapSize-카메라 사이즈
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        cameraMove();
        limitArea();
    }

    void cameraMove()
    {
        if (target == null)
            return;

        if (target.transform.position.y > 0)
            canMoveY = true;
        else if (transform.position.y == 0)
            canMoveY = false;

        if (canMoveY)
            transform.position = new Vector3(Vector3.Lerp(transform.position, target.position + offset, Time.deltaTime * smooth).x,
    Vector3.Lerp(transform.position, target.position + offset, Time.deltaTime * smooth).y, transform.position.z);
        else
            transform.position = new Vector3(Vector3.Lerp(transform.position, target.position + offset, Time.deltaTime * smooth).x,
       0, transform.position.z);

    }

    void limitArea()
    {
        float lx = mapSize.x - width;
        float clampX = Mathf.Clamp(transform.position.x, center.x - lx, center.x + lx);
        float ly = mapSize.y - height;
        float clampY = Mathf.Clamp(transform.position.y, center.y - ly, center.y + ly);
        transform.position = new Vector3(clampX, clampY, -10f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(center, mapSize * 2);
    }
}
