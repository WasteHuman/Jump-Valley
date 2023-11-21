using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollCubes : MonoBehaviour
{
    public GameObject cubes;

    private Vector3 screenPoint, offset;
    private float _lockedYPos;

    private void Update()
    {
        if (cubes = GameObject.FindGameObjectWithTag("Shop Cubes"))
        {
            if (cubes.transform.position.x > 0)
            {
                cubes.transform.position = Vector3.MoveTowards(cubes.transform.position, new Vector3(0f, cubes.transform.position.y, cubes.transform.position.z), Time.deltaTime * 10f);
            }
            else if (cubes.transform.position.x < -8f)
            {
                cubes.transform.position = Vector3.MoveTowards(cubes.transform.position, new Vector3(-8f, cubes.transform.position.y, cubes.transform.position.z), Time.deltaTime * 10f);
            }
        }
    }

    private void OnMouseDown()
    {
        _lockedYPos = screenPoint.x;
        offset = cubes.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        Cursor.visible = false;
    }

    private void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPos = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        curPos.y = _lockedYPos;
        cubes.transform.position = curPos;
    }

    private void OnMouseUp()
    {
        Cursor.visible = true;
    }
}
