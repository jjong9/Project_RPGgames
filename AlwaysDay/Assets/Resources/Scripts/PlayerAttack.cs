using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{
    public GameObject target;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            Attack();
        }
    }
    public void Attack()
    {
        float Distance = Vector3.Distance(target.transform.position, transform.position);
        
        if (Distance < 2)
        {
            MonsterHealth eh = (MonsterHealth)target.GetComponent("MonsterHealth");
            if(eh == null)
            {
                Debug.Log("MonsterHealth NULL !!!");
            }
            eh.AddjustCurrentHealth(-10);
        }
    }
}
