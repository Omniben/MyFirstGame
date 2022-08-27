using UnityEngine;

public class Target : CharacterStats
{

    public RandomSpawn spawnScript;

    public int point = 1;

    public void Update()
    {
 
        base.checkHealth();
    }


}
