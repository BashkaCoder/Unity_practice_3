using UnityEngine;
using Character = InfimaGames.LowPolyShooterPack.Character;

namespace Infima_Games.Low_Poly_Shooter_Pack___Free_Sample.Code.Legacy
{
    public class AmmoBox : MonoBehaviour, IInteractable
    {
        public void Interact()
        {
            print("AmmoBox picked up");
            var player = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
            player.FillAmmunition(30);
            Destroy(gameObject);
        }

        public string GetInteractionText()
        {
            return "Press 'E' to refill ammo";
        }
    }
}