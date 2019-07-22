﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangerManager : MonoBehaviour
{
    public void ChangeScene(int value)
    {
        SceneManager.LoadScene(value);
    }
}
