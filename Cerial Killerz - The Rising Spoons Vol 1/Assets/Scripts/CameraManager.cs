using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform target;
    public float xMargin = 1f;
    public float yMargin = 1f;
    public float xSmooth = 4f;
    public float ySmooth = 4f;

    public Vector2 XminMax;
    public Vector2 YminMax;


    // Start is called before the first frame update
    void Start()
    {
        
    }


    void LateUpdate()
    {
        if (target == null)
            return;

        Vector3 targetPos = transform.position;

        if(CheckXMargin() == true)
            targetPos.x = Mathf.Lerp(transform.position.x,
                            target.position.x,
                            Time.deltaTime);
        if (CheckYMargin() == true)
            targetPos.y = Mathf.Lerp(transform.position.y,
                                target.position.y,
                                Time.deltaTime);

        targetPos.x = Mathf.Clamp(targetPos.x, XminMax.x, XminMax.y);
        targetPos.y = Mathf.Clamp(targetPos.y, YminMax.x, YminMax.y);

        transform.position = targetPos;

    }

    bool CheckXMargin()
    {
        return Mathf.Abs(transform.position.x - target.position.x) > xMargin;
    }

    bool CheckYMargin()
    {
        return Mathf.Abs(transform.position.y - target.position.y) > yMargin;
    }
}
