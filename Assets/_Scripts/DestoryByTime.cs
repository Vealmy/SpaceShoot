﻿//#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryByTime : MonoBehaviour {

    public float lifetime = 2f;
    void Start() {
        Destroy(gameObject, lifetime);
    }
}
//