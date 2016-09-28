using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100;
    public float curHealth = 0;
    public UILabel Health_Label;
    public UIProgressBar Health_Bar;
    // Use this for initialization
    void Start()
    {
        
        curHealth = maxHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.C))
        {
            AddjustCurrentHealth(-1);
            Debug.Log(curHealth);
        }
        
    }

    public void AddjustCurrentHealth(int adj)
    {
        curHealth += adj;

        if (curHealth < 0)
            curHealth = 0;

        if (curHealth > maxHealth)
            curHealth = maxHealth;

        if (maxHealth < 0)
            maxHealth = 1;

        Health_Bar.value = curHealth / 100;
    }
}
