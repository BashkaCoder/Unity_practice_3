using Infima_Games.Low_Poly_Shooter_Pack___Free_Sample.Code.Legacy;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }
    
    public void Interact()
    {
        print("Chest opened");
        _animator.SetTrigger("Open");
    }

    public string GetInteractionText()
    {
        return "Press 'E' to open chest";
    }
}