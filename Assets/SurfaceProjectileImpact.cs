using Infima_Games.Low_Poly_Shooter_Pack___Free_Sample.Code.Legacy;
using UnityEngine;

public class SurfaceProjectileImpact : MonoBehaviour, IHaveProjectileReactionSurface
{
    [Header("Impact Effect Prefabs")]
    [SerializeField] private Transform [] _impactPrefabs;

    public void React(Vector3 impactPoint, Quaternion impactRotation)
    {
        Instantiate(
            _impactPrefabs[Random.Range(0, _impactPrefabs.Length)],
            impactPoint,
            impactRotation
            );
    }
}
