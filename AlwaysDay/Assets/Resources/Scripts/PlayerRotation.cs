using UnityEngine;
using System.Collections;

public class PlayerRotation : MonoBehaviour
{

    private float TurnSpeed = 500;
    Quaternion dir;
    private Vector3 mousePos;
    RaycastHit Hit;
    // Use this for initialization
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            int layermask = 1 << LayerMask.NameToLayer("Ground");
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out Hit, layermask))
            {
                mousePos = Hit.point;
                var vecDir = (mousePos - transform.position).normalized;
                vecDir.y = 0;

                dir = Quaternion.LookRotation(vecDir);

                transform.rotation = Quaternion.Slerp(transform.rotation, dir, TurnSpeed * Time.deltaTime);
            }
        }
    }
}