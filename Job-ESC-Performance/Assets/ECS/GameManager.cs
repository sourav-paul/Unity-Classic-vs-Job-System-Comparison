using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.UI;

namespace Example.ECS
{
    public class GameManager : MonoBehaviour
    {
        #region Game Manager Stuff

        public static GameManager GM;

        public float enemySpeed = 10f;
        public float leftBound = -10f;
        public float rightBount = 10f;

        public Text shipCounter = null;
        public int shipCount = 0;

        public GameObject shipPrefab = null;

        #endregion

        private EntityManager manager;

        void Start ()
        {
            manager = World.Active.GetOrCreateManager<EntityManager>();
        }

        void Update ()
        {
            if (Input.GetMouseButtonDown(0))
            {
                AddShips();
            }
        }

        private void AddShips()
        {
            NativeArray<Entity> entities = new NativeArray<Entity>(500, Allocator.Temp);

            manager.Instantiate(shipPrefab, entities);

            for (int i = 0; i < 500; i++)
            {
                float xVal = Random.Range(leftBound, rightBount);
                float yVal = Random.Range(0f, 10f);

                manager.SetComponentData(entities[i],
                                         new Position
                                         {
                                             Value = new float3(xVal, yVal, 0f)
                                         });
                manager.SetComponentData(entities[i],
                                         new Rotation
                                         {
                                             Value = new quaternion(0,0,0,0)
                                         });
//                manager.SetComponentData(entities[i],
//                                         new MoveSpeed
//                                         {
//                                             Value = enemySpeed
//                                         });
            }
            entities.Dispose();

            shipCount++;

            shipCounter.text = (shipCount*500).ToString();
        }
    }
}


