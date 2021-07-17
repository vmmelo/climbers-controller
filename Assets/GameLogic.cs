using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;

public class GameLogic : MonoBehaviour
{
    private Rigidbody2D body;

    void Awake() {
        AirConsole.instance.onMessage += OnMessage;
    }

    void Start()
    {
        body = transform.GetComponent<Rigidbody2D>();
        
    }

    void OnMessage(int fromDeviceID, JToken data) {
        Debug.Log("message from" + fromDeviceID + ", data: " + data);
        if(data["action"] != null && data["action"].ToString().Equals("interact")){
            Camera.main.backgroundColor = new Color(Random.Range(0f, 1f),Random.Range(0f, 1f),Random.Range(0f, 1f));
            
        }
        if(data["force"] != null && data["angle"] != null){
            Debug.Log(data["force"]);
            Debug.Log(data["angle"]);
            // Pular(10, 2, float.Parse(data["force"]));
        }
    }

    void OnDestroy() {
        if(AirConsole.instance != null) {
            AirConsole.instance.onMessage -= OnMessage;
        }
    }

    void Pular(float x , float y,float force)
    {
        Vector2 direcao = new Vector2(x*force, y);
        body.AddForce(direcao,ForceMode2D.Impulse);
    }
 }
