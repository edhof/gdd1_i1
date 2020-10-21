using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    public GameObject Spawner;
    public GameObject GameOverScreen;
    public GameObject PlayerModel1;
    public GameObject PlayerModel2;
    
    private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        if (ApplicationModel.PlayerModel == 0)
        {
            Player = Instantiate(PlayerModel1);
        }
        else
        {
            Player = Instantiate(PlayerModel2);
        }

        var script = Spawner.GetComponent<ScrollScript>();
        script.speed = Player.GetComponent<ScrollScript>().speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player == null)
        {
            Destroy(Spawner);
            GameOverScreen.SetActive(true);
        }
    }
}
