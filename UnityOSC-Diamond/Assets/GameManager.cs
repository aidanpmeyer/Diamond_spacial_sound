using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public OSC osc;
    public List<GameObject> diamonds;
    public List<Material> colors;
    public GameObject player;

    public Light Light;
    void Start()
    {
        int index = Random.Range(0, diamonds.Count);
        diamonds[index].SetActive(true);
        player.GetComponent<Renderer>().material = colors[index];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DiamondSwitch(GameObject hitDiamond)
    {
        if(Light.intensity < 1)
        {
            Light.intensity += 0.1f;
        }
        sendMessage(hitDiamond.name);
        GameObject nextDiamond = null;
        Material nextColor = null;
        do
        {
            int index = Random.Range(0, diamonds.Count);
             nextDiamond = diamonds[index];
            nextColor = colors[index];
        } while (hitDiamond == nextDiamond);

        nextDiamond.SetActive(true);
        Light.transform.TransformPoint(nextDiamond.transform.position);
        player.GetComponent<Renderer>().material = nextColor;
    }
    private void sendMessage(string color)
    {
        Debug.Log(color);
        int code = -1;
        switch (color)
        {
            case "white":
                // do something for white
                code= 0;
                break;
            case "yellow":
                // do something for yellow
                code = 1;
                break;
            case "blue":
                // do something for blue
                code = 2;
                break;
            case "pink":
                // do something for pink
                code = 3;
                break;
            default:
                // handle any other cases
                code = -1;
                break;
        }
        OscMessage message = new OscMessage();

        message.address = "/Diamond";
        message.values.Add(code);
        osc.Send(message);
    }
}
