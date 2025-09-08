using Photon.Deterministic;
using UnityEngine.Scripting;

namespace Quantum.QuantumUser.Simulation.Gameplay.Features.Armaments.Systems
{
    [Preserve]
    public unsafe class MarkProcessedOnObstacleCollisionSystem : SystemMainThreadFilter<MarkProcessedOnObstacleCollisionSystem.Filter>
    {
        public struct Filter
        {
            public EntityRef Entity;
            public UltimateArmament* UltimateArmament;
            public DestroyLayerMask* ObstacleLayerMask;
            public WorldPosition* Position;
        }

        public override void Update(Frame f, ref Filter filter)
        {
            var hits = f.Physics3D.OverlapShape(
                filter.Position->Value,
                FPQuaternion.Identity,
                Shape3D.CreateSphere(FP._0_25),
                filter.ObstacleLayerMask->Value
            );

            if (hits.Count > 0)
            {
                f.Add<Processed>(filter.Entity);
            }
        }
    }
}