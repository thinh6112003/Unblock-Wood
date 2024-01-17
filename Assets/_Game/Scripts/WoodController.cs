using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodController : MonoBehaviour
{
    [SerializeField] private int mouseRange;

    private Wood wood;

    private bool mouseDown;

    private Vector2 startPos;

    private void Awake()
    {
        wood = GetComponent<Wood>();
    }

   

    //private void OnMouseDrag()
    //{
    //    wood = this;
    //    wood.transform.position = Vector2.MoveTowards(wood.transform.position, Input.mousePosition, Time.deltaTime * speed);
    //}

}
