using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class TrackedImageController : MonoBehaviour
{
    private ARTrackedImageManager trackedImageManager;
    
    private Dictionary<string, GameObject> parkPanels;
    
    public GameObject panel_KHUN_KHAN;
    public GameObject panel_KHUN_NAN;
    public GameObject panel_SAITHONG;
    
    private string currentActivePanelName = null;

    void Awake()
    {
        trackedImageManager = FindFirstObjectByType<ARTrackedImageManager>();
        parkPanels = new Dictionary<string, GameObject>
        {
            { "KHUN_KHAN_NATIONAL_PARK", panel_KHUN_KHAN },
            { "KHUN_NAN_NATIONAL_PARK", panel_KHUN_NAN },
            { "SAITHONG_NATIONAL_PARK", panel_SAITHONG }
        };
        
        foreach (var panel in parkPanels.Values)
        {
            panel.SetActive(false);
        }
    }

    void Update()
    {
        bool anyTracked = false;

        foreach (ARTrackedImage trackedImage in trackedImageManager.trackables)
        {
            if (trackedImage.trackingState == TrackingState.Tracking)
            {
                string imageName = trackedImage.referenceImage.name;

                if (parkPanels.ContainsKey(imageName))
                {
                    if (currentActivePanelName != null && currentActivePanelName != imageName)
                    {
                        parkPanels[currentActivePanelName].SetActive(false);
                    }

                    parkPanels[imageName].SetActive(true);
                    currentActivePanelName = imageName;
                    anyTracked = true;
                    break; // เจอภาพที่ track แล้ว ไม่ต้องเช็คต่อ
                }
            }
        }
        
        if (!anyTracked && currentActivePanelName != null)
        {
            parkPanels[currentActivePanelName].SetActive(false);
            currentActivePanelName = null;
        }
    }
}