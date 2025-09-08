using Quantum.QuantumUser.Simulation.Gameplay.Features.Armaments.Systems;
using Quantum.QuantumUser.Simulation.Gameplay.Features.Ultimate.Systems;

namespace Quantum.QuantumUser.Simulation.Gameplay.Features.Armaments
{
    public class ArmamentFeature : SystemGroup
    {
        public ArmamentFeature() : base(nameof(ArmamentFeature), CreateSystems())
        {
            
        }

        private static SystemBase[] CreateSystems()
        {
            return new SystemBase[]
            {
                new MarkProcessedOnTargetLimitExceededSystem(),
                new MarkProcessedOnObstacleCollisionSystem(),
                new FollowProducerSystem(),

                new FinalizeProcessedArmamentsSystem(),
            };
        }
    }
}