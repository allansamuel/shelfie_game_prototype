using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class QuestAPI : MonoBehaviour
{
    private string URL;
    private int ChildProfileId;

	public QuestAPI(){
		AndroidJavaClass UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"); 
        AndroidJavaObject currentActivity = UnityPlayer.GetStatic<AndroidJavaObject>("UHVitoriaRegiaActivity");
        ChildProfileId = currentActivity.Call<int>("CHILD_PROFILE_ID");
		URL = currentActivity.Call<string>("SERVER_BASE_URL") + "/child_completed_quest/";
	}

    public IEnumerator CompleteQuestRequest(int QuestId)
    {
        string requestUrl = $"{URL}/child_profile/{ChildProfileId}/quest/{QuestId}";

        using(UnityWebRequest request = UnityWebRequest.Post(requestUrl, ""))
        {
            yield return request.SendWebRequest();
            switch(request.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                    print("Error " + request.result);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    print("Error " + request.result);
                    break;
                case UnityWebRequest.Result.Success:
                    print("Success " + request.result);
                    break;
            }
                
        }
    }
}
