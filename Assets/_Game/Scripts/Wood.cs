using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Wood : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int mouseRange;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private WoodType woodType;
    [SerializeField] private float scalePoint;
    [SerializeField] private LayerMask woodLayer;

    public bool checkMove = false;

    private Vector3 targetPos;

    public Direction direc;

    //private void OnMouseDrag()
    //{
    //    wood = this;
    //    wood.transform.position = Vector2.MoveTowards(wood.transform.position, Input.mousePosition, Time.deltaTime * speed);
    //}

    //private void Update()
    //{
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

    //    if (mouseDown == false && Input.GetMouseButtonDown(0))
    //    {
    //        startPos = Input.mousePosition;
    //        mouseDown = true;
    //    }

    //    if (mouseDown)
    //    {
    //        if (Input.mousePosition.y >= startPos.y + mouseRange)
    //        {
    //            mouseDown = false;
    //            Debug.Log("Swipe up");
    //            Move(Vector3.up);
    //            Debug.Log(wood.gameObject.name);
    //        }
    //        else if (Input.mousePosition.y <= startPos.y - mouseRange)
    //        {
    //            mouseDown = false;
    //            Debug.Log("Swipe down");
    //            Move(Vector3.down);
    //        }
    //        else if (Input.mousePosition.x <= startPos.x - mouseRange)
    //        {
    //            mouseDown = false;
    //            Debug.Log("Swipe left");
    //            Move(Vector3.left);
    //        }
    //        else if (Input.mousePosition.x >= startPos.x + mouseRange)
    //        {
    //            mouseDown = false;
    //            Debug.Log("Swipe right");
    //            Move(Vector3.right);
    //        }
    //    }

    //    if (mouseDown && Input.GetMouseButtonUp(0))
    //    {
    //        mouseDown = false;
    //    }

    //    transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    //}

    private void Update()
    {
        if (checkMove)
        {
            Vector3 direcv3= Vector3.zero;
            if (woodType == WoodType.Horizontal)
            {
                switch (direc)
                {
                    case Direction.Up:
                        direcv3 = Vector2.up;
                        transform.Translate(Vector3.up * 0.05f);
                        break;
                    case Direction.Down:
                        direcv3 = Vector2.down;
                        transform.Translate(Vector3.down * 0.05f);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (direc)
                {
                    case Direction.Left:
                        direcv3 = Vector2.left;
                        transform.Translate(Vector3.left * 0.05f);
                        break;
                    case Direction.Right:
                        direcv3 = Vector2.right;
                        transform.Translate(Vector3.right * 0.05f);
                        break;
                    default:
                        break;
                }
            }

            gameObject.GetComponent<Collider2D>().enabled = false;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, (Vector2)direcv3, scalePoint-0.07f, woodLayer);
            gameObject.GetComponent<Collider2D>().enabled = true;
            if (hit)
            {
                checkMove = false;
            }
        }
    }

    //public void Move(Vector3 moveDirection)
    //{
    //    targetPos += moveDirection;
    //}

    public void CheckRaycast(Vector3 direc)
    {
        gameObject.GetComponent<Collider2D>().enabled= false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, (Vector2)direc, scalePoint, woodLayer);
        gameObject.GetComponent<Collider2D>().enabled = true;
        //Debug.DrawLine(transform.position, transform.position + direc * scalePoint, Color.red);
        //Debug.Log(scalePoint);
        //Debug.Log(direc);
        //Debug.Log(transform.position);

        if (hit.collider != null)
        {
            Debug.Log("name"+hit.collider.name);
            Debug.Log("position"+transform.position);
            Debug.Log("direc" + direc);
            Debug.Log("!null");
            checkMove = false;
        }
        else
        {
            Debug.Log("null");
            checkMove = true;
        }
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawRay(transform.position, Vector3.left);
    //}

}


public enum Direction
{
    Up,
    Down,
    Left,
    Right
}

public enum WoodType
{
    Vertical,
    Horizontal
}
