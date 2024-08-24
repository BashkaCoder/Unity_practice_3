using Infima_Games.Low_Poly_Shooter_Pack___Free_Sample.Code.Legacy;
using TMPro;
using UnityEngine;

public class InteractFeature : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _interactionRange;
    [SerializeField] private TMP_Text _text;
    
    private void Update()
    {
        _text.gameObject.SetActive(false);
        
        RaycastHit hit;
        
        // Does the ray intersect any objects in layer 'Interactible'
        if (Physics.Raycast(Camera.main.transform.position, 
                            Camera.main.transform.TransformDirection(Vector3.forward), 
                            out hit, _interactionRange, _layerMask))
        {
            if (hit.transform.TryGetComponent<IInteractable>(out var interactible))
            {
                _text.gameObject.SetActive(true);
                _text.text = interactible.GetInteractionText();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactible.Interact();
                }
            }
        }
    }
}