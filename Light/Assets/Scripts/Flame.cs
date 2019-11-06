using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : InteractiveObject
{
    public override void CollisionResolve()
    {
        player.RecoverHealth();
        EventHandler.FlameCollectingEvent();
        gameObject.SetActive(false);
    }
}
