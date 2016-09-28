using UnityEngine;
using System.Collections;

public class MonsterUI : MonoBehaviour
{
    public Transform target;
    public int moveSpeed;
    public int rotationSpeed;
    private float Distance;
    private Transform myTransform;
    void Awake()
    {
        myTransform = transform;
    }

    // Use this for initialization
    void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Player");

        target = go.transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(target.transform.position, myTransform.position, Color.yellow);
        
        if(Distance < 3 && Distance > 0.7)
        {
            myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);
            myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
        }
        
        
        Distance = Vector3.Distance(myTransform.transform.position , target.transform.position);
        
    }
}
