using Moments;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Sprite backgroundImage;

    public Recorder recorder;

    private void Start()
    {
        Application.targetFrameRate = 12;

        recorder.Setup(true, (int)(Screen.width * 0.5f), (int)(Screen.height * 0.5f), 12, 60, 0, 40);

        recorder.Record();
    }
}
