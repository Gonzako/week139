using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private bool isOpen;

    public delegate void DoorEvents(Door door);
    public DoorEvents onDoorOpened;
    public DoorEvents onDoorOpenFailed;

    [SerializeField] private int _targetScene;

    private void SetDoorState(bool value)
    {
        isOpen =  value;
    }

    public void Use()
    {
        if (isOpen)
        {
            onDoorOpened?.Invoke(this);
            SceneManager.LoadScene(_targetScene);
        }
        else
        {
            onDoorOpenFailed?.Invoke(this);
        }
    }

}
