using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedStore : MonoBehaviour
{
    static SeedStore Instance;
    public int CurrentSeed;

    public void SeedCollect()
    {
        CurrentSeed++;
    }

    public void SeedUse()
    {
        CurrentSeed--;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
