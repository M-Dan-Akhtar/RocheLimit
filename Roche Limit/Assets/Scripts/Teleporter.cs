using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    private GameObject player;
    private GameObject camera;
    private Transform alternateStart;

    private Vector3 previousLocation;
    private Vector3 previousFacing;
    private Vector3 previousCamera;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        camera = GameObject.Find("Camera");
        alternateStart = GameObject.Find("AlternateTimelineStart").transform;

        previousLocation = new Vector3(alternateStart.position.x, alternateStart.position.y, alternateStart.position.z);
        previousCamera = new Vector3(alternateStart.position.x, camera.transform.position.y + 100.0f, camera.transform.position.z);
        previousFacing = new Vector3(player.transform.localScale.x, player.transform.localScale.y, player.transform.localScale.z);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("c"))
        {
            Vector3 currentLocation = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
            Vector3 currentCamera = new Vector3(camera.transform.position.x, camera.transform.position.y, camera.transform.position.z);
            Vector3 currentFacing = new Vector3(player.transform.localScale.x, player.transform.localScale.y, player.transform.localScale.z);

            player.GetComponent<TrailRenderer>().enabled = false;
            //StartCoroutine(WaitForSeconds(5));

            player.transform.position = previousLocation;
            player.transform.localScale = previousFacing;
            camera.transform.position = previousCamera;

            previousLocation = currentLocation;
            previousCamera = currentCamera;
            previousFacing = currentFacing;  

            player.GetComponent<TrailRenderer>().enabled = true;

        }
        
    }

    IEnumerator Wait(int s)
    {
        yield return new WaitForSeconds(s);
    }

}

public class FadeCamera : MonoBehaviour
{
    public AnimationCurve FadeCurve = new AnimationCurve(new Keyframe(0, 1), new Keyframe(0.6f, 0.7f, -1.8f, -1.2f), new Keyframe(1, 0));

    private float _alpha = 1;
    private Texture2D _texture;
    private bool _done;
    private float _time;
    private bool _reverse;

    public void Reset()
    {
        _done = false;
        _alpha = 1;
        _time = 0;
        _reverse = false;
    }

    public void Reverse()
    {
        _done = false;
        _alpha = 0;
        _time = 1;
        _reverse = true;
    }

    [RuntimeInitializeOnLoadMethod]
    public void RedoFade()
    {
        Reset();
    }

    public void OnGUI()
    {
        if (_texture == null) _texture = new Texture2D(1, 1);

        _texture.SetPixel(0, 0, new Color(0, 0, 0, _alpha));
        _texture.Apply();

        if (!_reverse)
        {
            if (!_done)
            {
                _time += Time.deltaTime;
                _alpha = FadeCurve.Evaluate(_time);
                GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), _texture);
            }

            if (_alpha <= 0) _done = true;
        } else
        {
            if (!_done)
            {
                _time -= Time.deltaTime;
                _alpha = FadeCurve.Evaluate(_time);
                GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), _texture);
            } else
            {
                GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), _texture);
            }

            if (_alpha >= 1) _done = true;
        }
    }
}
