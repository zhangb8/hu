using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MultiArray : MonoBehaviour {

    // Use this for initialization

    public GameObject[] array;

    public int Count()
    {
        return array.Length;
    }
}
