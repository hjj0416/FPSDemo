using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullentHole : MonoBehaviour {
    [Range(0f,10f)]
    [SerializeField] float time;

    private void Start()
    {
        Destroy(gameObject, time);
    }
}
