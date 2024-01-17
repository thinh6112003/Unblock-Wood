using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Wood : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int mouseRange;

    private Vector3 targetPos;

    private Wood wood;

    private bool mouseDown;

    private Vector2 startPos;

    private void Awake()
    {
        wood = GetComponent<Wood>();
    }

    private void OnMouseDown()
    {
        wood = this;
    }

    private void Start()
    {
        targetPos = transform.position;
    }

    private void Update()
    {
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
                wood.Move(Vector3.up);
            }
            else if (Input.mousePosition.y <= startPos.y - mouseRange)
            {
                mouseDown = false;
                Debug.Log("Swipe down");
                wood.Move(Vector3.down);
            }
            else if (Input.mousePosition.x <= startPos.x - mouseRange)
            {
                mouseDown = false;
                Debug.Log("Swipe left");
                wood.Move(Vector3.left);
            }
            else if (Input.mousePosition.x >= startPos.x + mouseRange)
            {
                mouseDown = false;
                Debug.Log("Swipe right");
                wood.Move(Vector3.right);
            }
        }

        if (mouseDown && Input.GetMouseButtonUp(0))
        {
            mouseDown = false;
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);   
    }

    public void Move(Vector3 moveDirection)
    {
        targetPos += moveDirection;
    }
}
