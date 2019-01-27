using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryManager : MonoBehaviour
{
    public Animator animComponent;
    public GameObject[] playerModels;
    public Transform[] locations;

    // Start is called before the first frame update
    void Start()
    {
        List<PlayerDetails.modelType> models = new List<PlayerDetails.modelType>();
        models.Add(DeathManager.instance.first);
        models.Add(DeathManager.instance.second);
        if (DeathManager.instance.players > 2)
        {
            models.Add(DeathManager.instance.third);
        }
        if (DeathManager.instance.players > 3)
        {
            models.Add(DeathManager.instance.fourth);
        }
        int i = 0;
        foreach (PlayerDetails.modelType model in models)
        {
            GameObject player = null;
            switch (model)
            {
                case PlayerDetails.modelType.Red:
                    player = Instantiate(playerModels[0], locations[i]);
                    player.GetComponent<Animator>().runtimeAnimatorController = animComponent.runtimeAnimatorController;
                    player.GetComponent<Animator>().SetInteger("Place", i + 1);
                    break;
                case PlayerDetails.modelType.Blue:
                    player = Instantiate(playerModels[1], locations[i]);
                    player.GetComponent<Animator>().runtimeAnimatorController = animComponent.runtimeAnimatorController;
                    player.GetComponent<Animator>().SetInteger("Place", i + 1);
                    break;
                case PlayerDetails.modelType.Yellow:
                    player = Instantiate(playerModels[2], locations[i]);
                    player.GetComponent<Animator>().runtimeAnimatorController = animComponent.runtimeAnimatorController;
                    player.GetComponent<Animator>().SetInteger("Place", i + 1);
                    break;
                case PlayerDetails.modelType.Green:
                    player = Instantiate(playerModels[3], locations[i]);
                    player.GetComponent<Animator>().runtimeAnimatorController = animComponent.runtimeAnimatorController;
                    player.GetComponent<Animator>().SetInteger("Place", i + 1);
                    break;
                case PlayerDetails.modelType.Purple:
                    player = Instantiate(playerModels[4], locations[i]);
                    player.GetComponent<Animator>().runtimeAnimatorController = animComponent.runtimeAnimatorController;
                    player.GetComponent<Animator>().SetInteger("Place", i + 1);
                    break;
            }
            i++;
        }
    }
}
