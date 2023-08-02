using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject _winText;

    public void Win()
    {
        _winText.SetActive(true);
    }
}
