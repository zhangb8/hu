using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Injection : Heal {
	void Awake()
    {
        name = "injection";
        cost = 2;
        type = "heal";
        val = 20;
    }
}
