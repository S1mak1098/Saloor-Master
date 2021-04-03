using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace ECS.Systems.Events
{
    sealed class GameLoseEventSystem : IEcsRunSystem
    {
        readonly EcsWorld _world = null;
        readonly GameData data;
        readonly ScoreService scoreService;

        EcsFilter<Components.Events.GameLoseEvent> filter;

        void IEcsRunSystem.Run()
        {
            foreach(var i in filter)
            {
                if(Input.anyKeyDown)
                {
                    UpdateResult(scoreService);
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }

        }


        private void UpdateResult(ScoreService Service)
        {
            Service.Result = 0;
            if (Service.BestResult < Service.Result)
            {
                Service.BestResult = Service.Result;
            }

            Service.Save();
        }
    }
}