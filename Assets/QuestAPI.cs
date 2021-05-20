using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class QuestAPI : MonoBehaviour
{
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
}
