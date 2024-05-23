using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    [SerializeField] private Camera arCam;
    [SerializeField] private ARRaycastManager _raycastManager;
    [SerializeField] private GameObject crosshair;
    private List<ARRaycastHit> _hits = new List<ARRaycastHit>();
    private Touch touch;
    private Pose pose;

    // Update is called once per frame
    void Update()
    {
        CrosshairCalculation();

        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                if (IsPointerOverUI(touch)) return;

                if (TrySelectObject(touch)) return;

                var placementObject = Instantiate(DataHandler.Instance.GetFurniture(), pose.position, pose.rotation);
                var anchor = new GameObject("PlacementAnchor").transform;
                anchor.position = pose.position;
                anchor.rotation = pose.rotation;
                placementObject.transform.parent = anchor;
            }
        }
    }

    bool IsPointerOverUI(Touch touch) //Kiểm tra xem vị trí chạm có phải là 1 Button không
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = new Vector2(touch.position.x, touch.position.y);

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        return results.Count > 0;
    }

    bool TrySelectObject(Touch touch)
    {
        Ray ray = arCam.ScreenPointToRay(touch.position);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.CompareTag("Interactable"))
            {
                return true;
            }
        }

        return false;
    }

    private RaycastHit hit;
    void CrosshairCalculation() // Tính toán vị trí đặt Crosshair
    {
        Vector3 origin = arCam.ViewportToScreenPoint(new Vector3(0.5f, 0.5f, 0));
        Ray ray = arCam.ScreenPointToRay(origin);

        if (_raycastManager.Raycast(ray, _hits))
        {
            pose = _hits[0].pose;
            crosshair.transform.position = pose.position;
            crosshair.transform.eulerAngles = new Vector3(90, 0, 0);
        }
        else if (Physics.Raycast(ray, out hit))
        {
            crosshair.transform.position = hit.point;
            crosshair.transform.up = hit.normal;
        }
    }
}
