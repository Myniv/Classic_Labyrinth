using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchTest : MonoBehaviour
{
    [SerializeField] GameObject visualTemplate;

    List<GameObject> visualList = new List<GameObject>();

    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount==0){
            return;
        }
        var touches = Input.touches;
        while (visualList.Count < touches.Length)
        {
            var visual = Instantiate(visualTemplate);
            visualList.Add(visual);
        }

        foreach (var visual in visualList)
        {
            visual.SetActive(false);
        }

        for (int i = 0; i < touches.Length; i++)
        {
            var touch = touches[i];
            var visual = visualList[i];
        
            switch (touch.phase)
            {
                case TouchPhase.Began:
                case TouchPhase.Stationary:
                case TouchPhase.Moved:
                    visual.SetActive(true);
                    var worldPost = cam.ScreenToWorldPoint(touch.position);
                    worldPost.z = 0;
                    visual.transform.position = worldPost;
                    break;
                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    break;
            }
        }
        if(Input.touchCount !=2){
            return;
        }

        // var touches = Input.touches;

        // var prevPos0 = touches[0].position - touches[0].deltaPosition;
        // var prevPos1 = touches[1].position - touches[1].deltaPosition;
        // var previousDistance = Vector2.Distance(prevPos0, prevPos1);
        // var currentDistance = Vector2.Distance(touches[0].position, touches[1].position);
        // var deltaDistance = currentDistance - previousDistance;

        // if(cam.orthographic){
        //     cam.orthographicSize -= deltaDistance*0.1f;
        //     cam.orthographicSize = Mathf.Clamp(cam.orthographicSize,2,15);        
        // } else{
        //     cam.transform.position += Vector3.forward * deltaDistance * 0.01f;
        //     var z = Mathf.Clamp(cam.transform.position.z,-10,1);
        //     cam.transform.position = new Vector3(cam.transform.position.x,cam.transform.position.y,z);
        // }

        // if(Input.touchCount!=1){
        //     return;
        // }

        // var touch = Input.GetTouch(0);
        // cam.transform.position -= (Vector3)touch.deltaPosition * 0.001f;


    }
}
