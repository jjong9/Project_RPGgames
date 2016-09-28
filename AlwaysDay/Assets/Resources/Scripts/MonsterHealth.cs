using UnityEngine;
using System.Collections;

public class MonsterHealth : MonoBehaviour {

    public int maxHealth = 100;
    public int curHealth = 0;
    public UILabel Health_Label;
    // Use this for initialization
    void Start()
    {
        curHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
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

        
    }
}
