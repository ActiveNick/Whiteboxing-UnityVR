﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MixedRealityToolkit.InputModule;
using MixedRealityToolkit.InputModule.InputHandlers;
using MixedRealityToolkit.InputModule.InputSources;
using MixedRealityToolkit.InputModule.EventData;
using MixedRealityToolkit.UX.Receivers;

public class ButtonHandler : InteractionReceiver {

    public float spawnDistance = 0.3f;
    public GameObject prefabCube;
    public GameObject prefabSphere;

    protected override void InputDown(GameObject obj, InputEventData eventData)
    {
        Debug.Log(obj.name + " : InputDown");

        if (eventData.PressType == InteractionSourcePressInfo.Select)
        {
            Ray aimingRay;
            Vector3 spawnPoint = Vector3.zero;
            if (eventData.InputSource.TryGetPointingRay(eventData.SourceId, out aimingRay))
            {
                spawnPoint = aimingRay.origin + (Vector3.Normalize(aimingRay.direction) * spawnDistance);
            }

            switch (obj.name)
            {
                case "HoloButton-Cube":
                    SpawnObject(prefabCube, spawnPoint);
                    break;
                case "HoloButton-Sphere":
                    SpawnObject(prefabSphere, spawnPoint);
                    break;
                case "HoloButton-Cylinder":
                    break;
                case "HoloButton-Reset":
                    break;
                default:
                    break;
            } 
        }
    }

    private void SpawnObject(GameObject prefab, Vector3 location)
    {
        if (prefab != null)
        {
            Rigidbody newObj = Instantiate(prefab, location, prefab.transform.rotation).GetComponent<Rigidbody>();
        }
    }
}
