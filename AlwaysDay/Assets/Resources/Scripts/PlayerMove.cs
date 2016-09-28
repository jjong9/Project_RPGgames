using UnityEngine;
using System.Collections;



public class PlayerMove : MonoBehaviour
{
    public enum STATE
    {
        IDLE,
        SIT,
        ATTACK,
        MOVE,
        JUMP,
        DEAD,

    }
    private float moveSpeed = 1;
    Quaternion dir;
    private Vector3 HitPos;
    public STATE state = STATE.IDLE;
    RaycastHit Hit;
    private float MoveStack;
    private Animator ani = null;
    private int setRun = 0;
    private bool toggleRun = false;
    private bool Sit;
    private Vector3 SitPos;
    private Vector3 DeadLocation;
    // Use this for initialization
    void Start()
    {

        ani = transform.GetComponentInChildren<Animator>();
        if (ani == null)
        {
            Debug.Log("Can't find Animator !!!");
            return;
        }


    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = HitPos - transform.position;
        Vector3 dirXZ = new Vector3(dir.x, 0, dir.z);
        Vector3 targetPos = transform.position + dirXZ;
        Vector3 framePos = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
        Vector3 moveDir = (framePos - transform.position) + Physics.gravity;
        float Health = GetComponent<PlayerHealth>().curHealth;

        if(Health <= 0)
        {
            state = STATE.DEAD;
        }
        if(state == STATE.DEAD)
        {
            DeadLocation = transform.position;
            ani.SetBool("Dead", true);
            
        }
        

        if (framePos == targetPos)
        {
            if(Sit == false)
            state = STATE.IDLE;
        }

        if (state == STATE.IDLE)
        {
            ani.SetFloat("speed", 0);
            if (Input.GetKeyDown(KeyCode.End))
            {
                if (Sit == false)
                {
                    ani.SetBool("Sit", true);
                    Sit = true;
                    state = STATE.SIT;
                    SitPos = transform.position;
                }
            }
        }
        if (state == STATE.SIT)
        {
            if (Input.GetMouseButtonDown(0))
            {
                state = STATE.IDLE;
                ani.SetBool("Sit", false);
                Sit = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (toggleRun == true)
            {
                toggleRun = false;
            }
            else
            {
                toggleRun = true;
            }

        }
        if (state == STATE.MOVE)
        {
            if (toggleRun == false)
            {
                ani.SetFloat("speed", 0.4f);
                var movePos = (HitPos - transform.position).normalized;
                transform.Translate(movePos * moveSpeed * Time.deltaTime);
            }
            else
            {
                ani.SetFloat("speed", 1);
                var movePos = (HitPos - transform.position).normalized;
                ani.SetFloat("speed", movePos.magnitude);
                transform.Translate(movePos * moveSpeed * Time.deltaTime * 1.5f);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            int layermask = 1 << LayerMask.NameToLayer("Ground");
            if (Physics.Raycast(ray, out Hit, 100f, layermask))
            {

                HitPos = Hit.point;
                if(state != STATE.SIT)
                state = STATE.MOVE;
            }
        }

    }
}