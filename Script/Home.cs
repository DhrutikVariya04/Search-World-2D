using UnityEngine;
using UnityEngine.UI;

public class Home : MonoBehaviour
{
    private string[] AllStrings = { "HOME", "CARS", "DHRUTIK", "GAME", "ROOM" };

    private GameObject[][] TextStorage = new GameObject[7][];

    private System.Random random = new System.Random();

    private bool Check = false;

    [SerializeField]
    GameObject Question, Alphabet, space, AnswerSaw;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < AllStrings.Length; i++)
        {
            Question.transform.GetChild(i).GetComponent<Text>().text = AllStrings[i];
        }

        for (int i = 0; i < 7; i++)
        {
            TextStorage[i] = new GameObject[6];
            for (int j = 0; j < 6; j++)
            {
                TextStorage[i][j] = Instantiate(Alphabet, space.transform);
                TextStorage[i][j].GetComponent<Text>().text = GetRandomAlphabet() + "";
            }
        }       

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Check = true;
        }

        if (Input.GetMouseButtonUp(1))
        {
            Check = false;

            for (int i = 0; i < AllStrings.Length; i++)
            {
                if (AllStrings[i] == AnswerSaw.GetComponentInChildren<Text>().text)
                {
                    print(AllStrings[i] + " == >> " + AllStrings[i].Length);
                }
                else
                {
                    Debug.Log("Wrong Answer");
                }

                AnswerSaw.GetComponentInChildren<Text>().text = "";
            }
        }

        if (Check)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null)
            {
                /*for (int i = 0; i < 7; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                       
                    }
                }*/

                

                /*AnswerSaw.GetComponentInChildren<Text>().text += hit.transform.GetComponent<Text>().text;
                print(hit.transform.GetComponent<Text>().text);*/
            }
        }

    }

    char GetRandomAlphabet()
    {
        // Get a random number between 0 and 25
        int randomNumber = random.Next(0, 26);

        // Convert the random number to a char ('A' is ASCII 65)
        char randomAlphabet = (char)('A' + randomNumber);
        return randomAlphabet;
    }

    void RandomString(GameObject A, int j)
    {
        //Random.Range(0, AllStrings.Length)
        var selectedstring = AllStrings[2];

        A.GetComponent<Text>().text = selectedstring[j] + "";
        print(selectedstring[j] + "");
    }
}
