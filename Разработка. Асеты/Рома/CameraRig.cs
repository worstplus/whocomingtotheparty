using System;
using UnityEngine;

public class CameraRig : MonoBehaviour
{
    public float dumping = 1.5f;
    public Vector2 offset = new Vector2(2f, 1f);
    public bool isLeft;
    private Transform cat;
    private int lastX;

    void Start()
    {
        offset = new Vector2(Mathf.Abs(offset.x), offset.y);
        FindPlayer(isLeft);
    }

    public void FindPlayer(bool CatIsLeft)
    {
        cat = GameObject.FindGameObjectWithTag("Player").transform;
        lastX = Mathf.RoundToInt(cat.position.x);
        if (CatIsLeft)
            transform.position = new Vector3(cat.position.x - offset.x, cat.position.y - offset.y, transform.position.z);
        else
            transform.position = new Vector3(cat.position.x + offset.x, cat.position.y + offset.y, transform.position.z);
    }

    void Update()
    {
        if (cat)
        {
            int currentX = Mathf.RoundToInt(cat.position.x);
            if (currentX > lastX) isLeft = false; else if (currentX < lastX) isLeft = true;
            lastX = Mathf.RoundToInt(cat.position.x);
            Vector3 target;
            if (isLeft)
            {
                target = new Vector3(cat.position.x - offset.x, cat.position.y + offset.y, transform.position.z);
            }
            else
            {
                target = new Vector3(cat.position.x + offset.x, cat.position.y + offset.y, transform.position.z);
            }
            Vector3 Position = Vector3.Lerp(transform.position, target, dumping * Time.fixedDeltaTime);
            transform.position = Position;
        }
    }
}