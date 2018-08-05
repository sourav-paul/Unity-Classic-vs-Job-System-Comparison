﻿using System;
using Unity.Entities;

namespace Example.ECS
{
    [Serializable]
    public struct MoveSpeed : IComponentData
    {
        public float Value;
    }

    public class MoveSpeedComponent : ComponentDataWrapper<MoveSpeed>{}
}

