using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using XboxCtrlrInput;

public class VictoryManager : MonoBehaviour
{
    public Animator animComponent;
    public GameObject[] playerModels;
    public Transform[] locations;
    bool canLeave = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CanLeaveTimer());
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

    private void Update()
    {
        if (canLeave)
        {
            if (Input.anyKey)
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    IEnumerator CanLeaveTimer()
    {
        yield return new WaitForSeconds(10);
        canLeave = true;
    }
}
