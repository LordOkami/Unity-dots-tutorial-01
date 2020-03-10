using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
public class MoverSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref Translation translation, ref MoveSpeedComponent moveSpeedComponent) => {
            translation.Value.y += moveSpeedComponent.moveSpeed * Time.DeltaTime;

            if(Mathf.Abs(translation.Value.y) > 5f)
            {
                moveSpeedComponent.moveSpeed = Mathf.Abs(moveSpeedComponent.moveSpeed) * -Mathf.Sign(translation.Value.y);
            }
        });
    }
}
