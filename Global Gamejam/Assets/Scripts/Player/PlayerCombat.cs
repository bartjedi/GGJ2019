﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private PlayerController controller;
    private PlayerMovement playerMovement;
    [SerializeField]
    private float shovedRecoveryTime = 1.0f, attackReach = 1.5f, shoveCooldown = 0.5f, 
    groundPoundForce = 300f, poundReach = 0.1f, groundPoundCooldown = 0.4f, poundStunDuration = 1.5f;
    private float shoveRayStart, poundRayStart;
    [SerializeField]
    private Transform pushRayStart;

    private float shovedTime = float.NegativeInfinity, shoveTime = float.NegativeInfinity, poundedTime = float.NegativeInfinity;
    private bool isPounding = false, targetPounded = false, isPounded = false, canPound = false;

    [SerializeField]
    private GameObject poundedEffect;

    private IEnumerator delayedPounder;

    [SerializeField]
    GroundPoundAttack groundPound;

    [SerializeField]
    private float minSpeed, maxSpeed, maxSpeedAtTime;
    private float currentTime = 0f, shoveForce = 1.0f;

    private void Awake()
    {
        delayedPounder = PoundDisabler();
        controller = GetComponent<PlayerController>();
        playerMovement = GetComponent<PlayerMovement>();
        shoveRayStart = GetComponent<Collider>().bounds.extents.x * 2f;
        poundRayStart = GetComponent<Collider>().bounds.extents.y;
    }

    private void Start()
    {
        StartCoroutine(Timer());
    }

    private void Update()
    {
        if (controller.input.shove && shoveTime + shoveCooldown < Time.time)
        {
            Shove();
        }
        if (!isPounding)
        {
            if (controller.input.groundPound && !controller.movement.grounded && (Time.time - playerMovement.jumpStartTime) > groundPoundCooldown
                && canPound && Mathf.Abs(controller.movement.GetVelocity().y) > 0.01f)
            {
                GroundPound();
            }
        }
        controller.input.allowMovement = shovedTime + shovedRecoveryTime < Time.time;
        controller.input.allowJump = (shovedTime + shovedRecoveryTime < Time.time) && !isPounding;
        if (isPounding)
        {
            isPounding = !controller.movement.grounded && controller.input.allowAttack && controller.input.allowInput;
            if (isPounding == false)
            {
                StopCoroutine(delayedPounder);
                delayedPounder = PoundDisabler();
                StartCoroutine(delayedPounder);
            }
            else if (controller.movement.GetVelocity().y > 0.1f)
            {
                isPounding = false;
                groundPound.gameObject.SetActive(false);
            }
        }
        if (targetPounded)
        {
            targetPounded = !controller.movement.grounded;
        }
        if (isPounded)
        {
            isPounded = poundedTime + poundStunDuration > Time.time;
            controller.input.allowInput = !isPounded;
            poundedEffect.SetActive(isPounded);
        }
        if (!isPounding && !canPound)
        {
            canPound = controller.movement.grounded;
        }
    }

    private IEnumerator Timer()
    {
        while (true)
        {
            yield return null;
            shoveForce = Mathf.Lerp(minSpeed, maxSpeed, currentTime / maxSpeedAtTime);
            currentTime += Time.deltaTime;

            if (currentTime > maxSpeedAtTime)
                break;
        }
    }

    private PlayerController[] shoveTargets
    {
        get
        {
            List<PlayerController> controllers = new List<PlayerController>();

            RaycastHit[] hits;
            hits = Physics.RaycastAll(pushRayStart.position, transform.right, attackReach);
            for (int i = 0; i < hits.Length; i++)
            {
                PlayerController c;
                c = hits[i].transform.GetComponent<PlayerController>();
                if (c != this.controller && c != null)
                {
                    controllers.Add(c);
                }
            }
            return controllers.ToArray();
        }
    }

    private PlayerController poundTarget
    {
        get
        {
            PlayerController c = null;

            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, poundRayStart + attackReach))
            {
                c = hit.transform.GetComponent<PlayerController>();
                if (c == this.controller)
                {
                    c = null;
                }
            }
            return c;
        }
    }

    

    public void PoundEnemy(PlayerController enemy)
    {
        if (enemy != controller)
        {
            enemy.combat.GetPounded();
        }
    }

    public void PoundButton(ButtonScript button)
    {
        button.Trigger(this.gameObject);
    }

    private void CheckPoundHit()
    {
        PlayerController target = poundTarget;
        if (target != null)
        {
            target.combat.GetPounded();
            targetPounded = true;
        }
    }

    public void GetPounded()
    {
        poundedTime = Time.time;
        controller.movement.Stun();
        isPounded = true;
    }

    private void GroundPound()
    {
        groundPound.gameObject.SetActive(true);
        isPounding = true;
        canPound = false;
        controller.movement.ResetVelocity();
        controller.movement.ApplyForce(Vector3.down * groundPoundForce);
    }

    public void GetShoved(Vector3 direction, float force)
    {
        shovedTime = Time.time;
        controller.movement.ApplyForce(direction * force + new Vector3(0.0f, 1f, 0.0f));
    }

    private void Shove()
    {
        PlayerController[] targets = shoveTargets;
        controller.animations.Shove();
        shoveTime = Time.time;
        foreach (PlayerController target in targets)
        {
            if (target != null)
            {
                target.combat.GetShoved(transform.right, shoveForce);
            }
        }
    }

    private IEnumerator PoundDisabler()
    {
        float poundEndTime = Time.time;
        Vector3 originalScale = groundPound.transform.localScale;
        while(Time.time < poundEndTime + 0.1f) {
            groundPound.transform.localScale += Vector3.one * 2.5f * (Time.deltaTime / 0.1f);
            yield return new WaitForEndOfFrame();
        }
        groundPound.transform.localScale = originalScale;
        groundPound.gameObject.SetActive(false);
        canPound = true;
    }
}
