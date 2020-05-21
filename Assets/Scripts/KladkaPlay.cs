using UnityEngine;

public class KladkaPlay : MonoBehaviour
{
    public GameObject brik1;
    public int counterBrick = 0;


    private float[,] arreyBrick = {
                
            // Первый ряд
            {1, 1,0,0.24f,0,0 },
            {1, 1,0,0.48f,0,0 },
            {1, 1,0,0.72f,0,0 },
            {1, 1,0,0.96f,0,0 },
            {1, 1,0,1.2f,0,0 },
            // Второй ряд
            /*{2,1,0,0.24f,0,0 },
            {2,1,0,0.48f,0,0 },
            {2, 1,0,0.72f,0,0 },*/

    };

    //private GameObject[] bricks = new GameObject[];

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (counterBrick < arreyBrick.Length / 6)
        {
            GameObject currentBrick = Instantiate(brik1);
            currentBrick.transform.position = Vector3.Lerp(new Vector3(arreyBrick[counterBrick, 3], arreyBrick[counterBrick, 4], arreyBrick[counterBrick, 5]),
                                                                        new Vector3(arreyBrick[counterBrick, 3], 3, arreyBrick[counterBrick, 5]), Time.deltaTime * 10);
            //currentBrick.GetComponent<Rigidbody>().MovePosition(new Vector3(arreyBrick[counterBrick, 3], arreyBrick[counterBrick, 4], arreyBrick[counterBrick, 5]));
            counterBrick++;
        }
        
    }
}
