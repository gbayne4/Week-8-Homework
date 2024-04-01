using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.Networking;

public class WebManager : MonoBehaviour
{
    // Start is called before the first frame update

    string url1 = "https://jsonplaceholder.typicode.com/todos/1";
    string url2 = "https://jsonplaceholder.typicode.com/comments";
    string url3 = "https://raw.githubusercontent.com/Biuni/PokemonGO-Pokedex/master/pokedex.json";
    void Start()
    {
        //StartCoroutine(GetJsonFromUrl(url1, RecievedJson1));

        //StartCoroutine(GetJsonFromUrl(url2, RecievedJson2));

        StartCoroutine(GetJsonFromUrl(url3, RecievedMyJson));


    }

    IEnumerator GetJsonFromUrl(string url, System.Action<string> callback)
    {
        //Set string
        string jsonText;

        //online web request
        UnityWebRequest www = UnityWebRequest.Get(url);
        //Header for this request
        www.SetRequestHeader("Content-Type", "application/json");

        //Sending web request, need to wait until response from the server
        yield return www.SendWebRequest();

        //check if server return value is successsful or error
        if (www.result != UnityWebRequest.Result.Success)
        {
            //Something went wrong
            jsonText = www.error;
        }
        else
        {
            //success
            jsonText = www.downloadHandler.text;
        }

        callback(jsonText);
        www.Dispose();
    }

    public void RecievedJson1(string jsonTextRecieved)
    {
        print(jsonTextRecieved);

        JsonReciever1 receiver = JsonUtility.FromJson<JsonReciever1>(jsonTextRecieved);

        print(receiver.userId + "\n" + receiver.title);
        receiver.id += 1;

    }

    public void RecievedJson2(string jsonTextRecieved)
    {
        // print(jsonTextRecieved);

        jsonTextRecieved = "{\"comments\":" + jsonTextRecieved + "}";
        JsonReceiver2 receiver = JsonUtility.FromJson<JsonReceiver2>(jsonTextRecieved);

        Comment[] comments = receiver.comments;

        foreach (Comment comment in comments)
        {
            print(comment.email + ":" + comment.body);
        }
    }

    public void RecievedMyJson(string jsonTextRecieved)
    {
        jsonTextRecieved = "{\"pokemon\":" + jsonTextRecieved + "}";
        JsonRecieverMyAttempt receiver = JsonUtility.FromJson<JsonRecieverMyAttempt>(jsonTextRecieved);

        Pokemon[] myPokemon = receiver.myPokemon;
     
        foreach (Pokemon pokemon in myPokemon)
        {
            print("This is " + myPokemon.name + ". They are " + myPokemon.height + " tall, with " + myPokemon.weaknesses + " weaknesses.");
        }

    }
}