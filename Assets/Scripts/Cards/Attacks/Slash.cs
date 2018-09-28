using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : Attack {

    void Awake()
    {
        name = "Slash";
        cost = 2;

        
    }

    int use()
    {
        return dmg;
    }

}
