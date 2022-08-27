using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{

    private PlayerHUD hud;

    void Start()
    {

        getReferences();
        initVariables();
    }

    private void getReferences()
    {

        hud = GetComponent<PlayerHUD>();
    }


    public override void checkHealth()
    {

        base.checkHealth();
        hud.UpdateHealth(health);
    }
}
