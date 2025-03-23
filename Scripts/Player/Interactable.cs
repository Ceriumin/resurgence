using UnityEngine;
using UnityEngine.Events;


public class InteractionObject : MonoBehaviour
{
    [SerializeField]
    UnityEvent m_OnInteraction;

    public void DoInteraction()
    {
        m_OnInteraction.Invoke();
        Cursor.lockState = CursorLockMode.None;

    }
}