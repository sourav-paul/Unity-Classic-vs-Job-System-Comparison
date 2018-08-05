using Unity.Jobs;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Jobs;

namespace Example.JobSystem
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

        void Start()
        {
            GM = this;

            transforms = new TransformAccessArray(0, -1);
        }

        TransformAccessArray transforms;
        MovementJob          moveJob;
        JobHandle            moveHandle;


        private void OnDisable()
        {
            moveHandle.Complete();
            transforms.Dispose();
        }

        void Update()
        {
            moveHandle.Complete();

            if (Input.GetMouseButtonDown(0))
            {
                AddShips();
            }

            moveJob = new MovementJob()
            {
                moveSpeed = enemySpeed,
                deltaTime = Time.deltaTime
            };

            moveHandle = moveJob.Schedule(transforms);

            JobHandle.ScheduleBatchedJobs();
        }

        private void AddShips()
        {
            moveHandle.Complete();

            transforms.capacity = transforms.length + 500;

            for (int i = 0; i < 500; i++)
            {
                var obj =
                    Instantiate(shipPrefab,
                                new Vector3(Random.Range(leftBound,
                                                         rightBount),
                                            -5f,
                                            0f),
                                Quaternion.identity) as GameObject;

                transforms.Add(obj.transform);
            }

            shipCount++;

            shipCounter.text = (shipCount*500).ToString();
        }
    }
}
