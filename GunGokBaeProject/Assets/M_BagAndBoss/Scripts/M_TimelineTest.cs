using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class M_TimelineTest : MonoBehaviour
{
    private PlayableDirector pd;
    public TimelineAsset[] ta;
    // Start is called before the first frame update
    void Start()
    {
        pd = GetComponent<PlayableDirector>();

        pd.Play(ta[0]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
