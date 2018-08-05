using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Example.Classic
{
    public class MovementController : MonoBehaviour
    {
        void Update()
        {
            Vector3 pos = transform.position;
            pos += transform.up *
                   GameManager.GM.enemySpeed *
                   Time.deltaTime;

            transform.position = pos;
        }
    }
}


