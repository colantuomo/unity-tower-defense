using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PathMovement : MonoBehaviour
{
    public float moveSpeed = 1f;
    public List<Transform> paths;
    public bool canMove = true;

    private int _pathIndex = 0;

    void Update()
    {
        if (canMove)
        {
            Transform currentPath;
            try
            {
                currentPath = paths[_pathIndex];
            }
            catch (Exception)
            {
                currentPath = null;
            }
            if (currentPath != null)
            {
                Vector3 currentPosition = Vector3.MoveTowards(transform.position, new Vector3(currentPath.position.x, transform.position.y, currentPath.position.z), moveSpeed * Time.deltaTime);
                transform.position = currentPosition;
                float MIN_DISTANCE = .3f;
                if (Vector3.Distance(transform.position, currentPath.position) <= MIN_DISTANCE)
                {
                    _pathIndex++;
                }
            }
        }
    }
}
