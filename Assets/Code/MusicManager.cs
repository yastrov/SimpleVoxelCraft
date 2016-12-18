﻿/*See https://vilbeyli.github.io/Unity3D-How-to-Make-a-Pause-Menu/ for details! */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    public void SetVolume(float val)
    {
        GetComponent<AudioSource>().volume = val;
    }
}
