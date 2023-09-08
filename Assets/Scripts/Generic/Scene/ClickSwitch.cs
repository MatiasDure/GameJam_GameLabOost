using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSwitch : MonoBehaviour
{
    [SerializeField] private string _sceneName;

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown) SceneManager.Instance.SwitchScene(_sceneName);    
    }
}
