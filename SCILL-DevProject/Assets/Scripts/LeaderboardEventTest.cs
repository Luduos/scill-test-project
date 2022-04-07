using System.Collections;
using System.Collections.Generic;
using SCILL;
using SCILL.Model;
using UnityEngine;

public class LeaderboardEventTest : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            EventMetaData metaData = new EventMetaData()
            {
                amount = 1
            };
            SCILLManager.Instance.SendEventAsync("kill-enemy", "single",metaData );
        }
    }
}
