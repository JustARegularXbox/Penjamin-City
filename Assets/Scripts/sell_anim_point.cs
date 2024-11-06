using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class sell_anim_point : MonoBehaviour
{
    private Vector3 targetPos = new Vector3(5.5f, -1.3f, 4.03f);
    public Transform point;
    public float speed;
    public void Move_Point()
    {
        point.position = Vector3.MoveTowards(point.position, targetPos, speed);
    }
}
