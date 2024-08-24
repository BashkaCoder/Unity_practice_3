using Infima_Games.Low_Poly_Shooter_Pack___Free_Sample.Code.Legacy;
using UnityEngine;
using Random = UnityEngine.Random;

public class ColoredCube : MonoBehaviour, IInteractable
{
    private MeshRenderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();
    }
    
    public void Interact()
    {
        print("Cube changed color");
        _renderer.material.color = new Color(Random.value, Random.value, Random.value , 1.0f);
    }

    public string GetInteractionText()
    {
        return "Press 'E' to change cube color";
    }
}