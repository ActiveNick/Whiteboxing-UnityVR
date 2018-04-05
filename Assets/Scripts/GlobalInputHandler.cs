using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MixedRealityToolkit.InputModule;
using MixedRealityToolkit.InputModule.InputHandlers;
using MixedRealityToolkit.InputModule.InputSources;
using MixedRealityToolkit.InputModule.EventData;

public class GlobalInputHandler : MonoBehaviour, IInputHandler
{
    public GameObject popupMenu;
    public float popuMenuDistance = 0.5f;

    // Use this for initialization
    void Start()
    {
        // Make sure the popup menu isn't shown when we start
        popupMenu.SetActive(false);
        InputManager.Instance.PushFallbackInputHandler(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnInputDown(InputEventData eventData)
    {
        Ray userRay;
        // if the user presses the menu button on either controller
        if (eventData.PressType == InteractionSourcePressInfo.Menu)
        {
            if (!popupMenu.activeSelf) {
                // Reposition the popup menu only if we're about to show it (i.e. was inactive)
                if (eventData.InputSource.TryGetPointingRay(eventData.SourceId, out userRay))
                {
                    popupMenu.transform.position = userRay.origin + (Vector3.Normalize(userRay.direction) * popuMenuDistance);
                }
            }
            // Toggle popup menu visibility
            popupMenu.SetActive(!popupMenu.activeSelf);
        }
    }

    public void OnInputUp(InputEventData eventData)
    {
        
    }
}