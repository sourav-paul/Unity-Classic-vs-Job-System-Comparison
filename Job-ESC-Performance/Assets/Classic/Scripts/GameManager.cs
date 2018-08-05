using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Example.Classic
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager GM;

        public float        enemySpeed  =   10f;
        public float        leftBound   =   -10f;
        public float        rightBount  =   10f;

        public Text         shipCounter =   null;
        public string       shipText    =   "";
        public int          shipCount   =   0;

        public GameObject   shipPrefab  =   null;

        void Start()
        {
            GM = this;
            shipText = shipCounter.text;
        }

        void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
                AddShips();
            }
        }

        private void AddShips()
        {
            for (int i = 0; i < 500; i++)
            {
                Instantiate(shipPrefab,
                    new Vector3(Random.Range(leftBound,
                            rightBount),
                        -5f,
                        0f),
                    Quaternion.identity);

                shipCount++;

                shipCounter.text = shipCount.ToString();
            }
        }
    }
}

