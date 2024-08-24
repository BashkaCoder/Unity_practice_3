using UnityEngine;

namespace Infima_Games.Low_Poly_Shooter_Pack___Free_Sample.Code.Legacy
{
    public interface IHaveProjectileReactionSurface : IHaveProjectileReaction
    {
        void React(Vector3 impactPoint, Quaternion impactRotation);
    }
}