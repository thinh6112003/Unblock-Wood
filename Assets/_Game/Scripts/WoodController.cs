using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodController : MonoBehaviour
{
    [SerializeField] private int mouseRange;
    [SerializeField] private float speed;

    private Wood wood;

    private bool mouseDown;

    private Vector2 startPos;

    private Vector3 targetPos;

    private void Awake()
    {
        wood = GetComponent<Wood>();
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null && Input.GetMouseButtonDown(0))
        {
            wood = hit.collider.GetComponent<Wood>();
        }

        //if (mouseDown == false && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        //{
        //    startPos = Input.touches[0].position;
        //    mouseDown = true;
        //}

        //if (mouseDown)
        //{
        //    if (Input.touches[0].position.y >= startPos.y + mouseRange)
        //    {
        //        mouseDown = false;
        //        Debug.Log("Swipe Up");
        //        wood.Move(Vector3.up);
        //    }
        //    else if (Input.touches[0].position.y <= startPos.y - mouseRange)
        //    {
        //        mouseDown = false;
        //        Debug.Log("Swipe down");
        //        wood.Move(Vector3.down);
        //    }
        //    else if (Input.touches[0].position.x <= startPos.x - mouseRange)
        //    {
        //        mouseDown = false;
        //        Debug.Log("Swipe left");
        //        wood.Move(Vector3.left);
        //    }
        //    else if (Input.touches[0].position.x >= startPos.x + mouseRange)
        //    {
        //        mouseDown = false;
        //        Debug.Log("Swipe right");
        //        wood.Move(Vector3.right);
        //    }
        //}

        //if (mouseDown && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended)
        //{
        //    mouseDown = false;
        //}

        // PC

        if (mouseDown == false && Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
            mouseDown = true;
        }

        if (mouseDown)
        {
            if (Input.mousePosition.y >= startPos.y + mouseRange)
            {
                mouseDown = false;
                Debug.Log("Swipe up");
                wood.direc = Direction.Up;
                //wood.CheckRaycast(Vector3.up);
                wood.checkMove = true;
            }
            else if (Input.mousePosition.y <= startPos.y - mouseRange)
            {
                mouseDown = false;
                Debug.Log("Swipe down");
                wood.direc = Direction.Down;
                //wood.CheckRaycast(Vector3.down);
                wood.checkMove = true;
            }
            else if (Input.mousePosition.x <= startPos.x - mouseRange)
            {
                mouseDown = false;
                Debug.Log("Swipe left");
                wood.direc = Direction.Left;
                //wood.CheckRaycast(Vector3.left);
                wood.checkMove = true;
            }
            else if (Input.mousePosition.x >= startPos.x + mouseRange)
            {
                mouseDown = false;
                Debug.Log("Swipe right");
                wood.direc = Direction.Right;
                //wood.CheckRaycast(Vector3.right);
                wood.checkMove = true;
            }
        }

        if (mouseDown && Input.GetMouseButtonUp(0))
        {
            mouseDown = false;
        }

        //transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }
}
