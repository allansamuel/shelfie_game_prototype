using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class QuestAPI : MonoBehaviour
{
    
    [HideInInspector]
    private string BaseURL = "http://10.0.0.103:8080/child_completed_quest/";

    public QuestAPI()
    {

    }

    public IEnumerator CompleteQuestRequest(string ChildProfileId, string QuestId)
    {
        string requestUrl = $"{BaseURL}/child_profile/{int.Parse(ChildProfileId)}/quest/{int.Parse(QuestId)}";

        using(UnityWebRequest request = UnityWebRequest.Post(requestUrl, ""))
        {
            yield return request.SendWebRequest();
            switch(request.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                    print("Error: " + request.result);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    print("Error: " + request.result);
                    break;
                case UnityWebRequest.Result.Success:
                    print("Success: " + request.result);
                    break;
            } 
        }
    }

    public string getIntentData () {
    #if (!UNITY_EDITOR && UNITY_ANDROID)
        return CreatePushClass (new AndroidJavaClass ("com.unity3d.player.UnityPlayer"));
    #endif
        return "5";
    }

    public string CreatePushClass (AndroidJavaClass UnityPlayer) {
        AndroidJavaObject currentActivity = UnityPlayer.GetStatic<AndroidJavaObject> ("currentActivity");
        AndroidJavaObject intent = currentActivity.Call<AndroidJavaObject> ("getIntent");
        AndroidJavaObject extras = GetExtras (intent);
        string result = GetProperty (extras, "CHILD_PROFILE_ID");
        print(result);
        return result;
    }

    private AndroidJavaObject GetExtras (AndroidJavaObject intent) {
        AndroidJavaObject extras = null;

        try {
            extras = intent.Call<AndroidJavaObject> ("getExtras");
        } catch (Exception e) {
            Debug.Log (e.Message);
        }

        return extras;
    }

    private string GetProperty (AndroidJavaObject extras, string name) {
        string s = string.Empty;

        try {
            s = extras.Call<string> ("getString", name);
        } catch (Exception e) {
            Debug.Log (e.Message);
        }

        return s;
    }
}
