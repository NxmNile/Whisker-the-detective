using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseGameObject : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;

    public void SetActiveGameObject()
    {
        _gameObject.SetActive(false);
    }
}
