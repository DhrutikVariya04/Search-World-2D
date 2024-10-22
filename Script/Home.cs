using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Home : MonoBehaviour
{
    string[] AllStrings = { "HOME", "CARS", "DHRUTIK", "GAME", "ROOM" };

    private System.Random random = new System.Random();

    [SerializeField]
    GameObject Question, Alphabet, space;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < AllStrings.Length; i++)
        {
            Question.transform.GetChild(i).GetComponent<Text>().text = AllStrings[i];
        }

        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                GameObject A = Instantiate(Alphabet, space.transform);
                A.GetComponent<Text>().text = GetRandomAlphabet()+"";
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    char GetRandomAlphabet()
    {
        // Get a random number between 0 and 25
        int randomNumber = random.Next(0, 26);

        // Convert the random number to a char ('A' is ASCII 65)
        char randomAlphabet = (char)('A' + randomNumber);
        return randomAlphabet;
    }

    void RandomString(GameObject A,int j)
    {
        //Random.Range(0, AllStrings.Length)
        var selectedstring = AllStrings[2];

        A.GetComponent<Text>().text = selectedstring[j] + "";
        print(selectedstring[j] + "");
    }
}
