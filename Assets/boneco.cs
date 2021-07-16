using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;
public class boneco : MonoBehaviour
{
    private Rigidbody2D body;

    // Start is called before the first frame update

    private void Awake()
    {
        AirConsole.instance.onMessage += OnMessage;
    }
    void OnMessage(int fromDeviceID, JToken data) {
        if (data["action"] != null && data["action"].ToString().Equals("interact")) {
            Pular(10, 2, -2);
        }
    }
    void Start()
    {
        body = transform.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Pular(10,2,-2);
        }
    }
    void Pular(float x , float y,float force)
    {
        Vector2 direcao = new Vector2(x*force, y);
        body.AddForce(direcao,ForceMode2D.Impulse);
    }
}
