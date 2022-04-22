using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;

public class SelectSpawn : NetworkBehaviour {
    public Projectiles isLocalpl
    {
        get;
        set;
    }
    public ProjectileGO isLocalplayer
    {
        get;
        set;
    }
    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        if (isLocalPlayer)
        {
            if (this.GetComponent<Projectiles>() != null)
            {
                this.GetComponent<Projectiles>().enabled = true;
                isLocalpl = this.GetComponent<Projectiles>();
            }
            if (this.GetComponent<ProjectileGO>() != null)
            {
                this.GetComponent<ProjectileGO>().enabled = true;
                isLocalplayer = this.GetComponent<ProjectileGO>();
            }
        }
    }
}
