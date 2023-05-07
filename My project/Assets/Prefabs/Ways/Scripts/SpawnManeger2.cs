using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManeger2 : MonoBehaviour
{
    [SerializeField] private List<GameObject> Bots;
    private float spawnRate = 12f;
    private int index;
    private int indexR;
    public GameObject Player;
    [SerializeField] private float add = 20;
    public GameObject roadLine;
    public GameObject []roadLines=new GameObject[4];

    public float wayX;
    public float wayY;
    public float wayZ;
  
    // Start is called before the first frame update
    void Start()
    {
        roadLines[0] = GameObject.Find("RoadLine1");
        roadLines[1] = GameObject.Find("RoadLine2");
        roadLines[2] = GameObject.Find("RoadLine3");
        roadLines[3] = GameObject.Find("RoadLine4");

      
        spawnBots();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        roadLines[0] = GameObject.Find("RoadLine1");
        roadLines[1] = GameObject.Find("RoadLine2");
        roadLines[2] = GameObject.Find("RoadLine3");
        roadLines[3] = GameObject.Find("RoadLine4");
    }

    
   public  void  spawnBots()
    {

            add = wayZ - 800;
            for (int i = 0; i < 10; i++)
            {
               
                index = Random.Range(0, Bots.Count);
                indexR= Random.Range(0, roadLines.Length);
                roadLine = roadLines[indexR];
                Instantiate(Bots[index], RandomSpawnPosition(index), Bots[index].transform.rotation);
                add += 40;
            }
    }
    public Vector3 RandomSpawnPosition(int index)
    {

        return new Vector3(roadLine.transform.position.x, Bots[index].transform.position.y, Random.Range(add,add+20));
    }
    
   
}