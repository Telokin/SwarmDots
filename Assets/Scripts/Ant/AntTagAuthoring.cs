using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class AntTagAuthoring : MonoBehaviour
{


}

public class AntTagBaker : Baker<AntTagAuthoring>
{
    public override void Bake(AntTagAuthoring authoring)
    {
        AddComponent(new AntTag());
    }
}
