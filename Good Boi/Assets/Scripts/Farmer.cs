using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farmer : MonoBehaviour
{
    [SerializeField]
    private GameObject chickenPrefab;
    [SerializeField]
    private GameObject stickPrefab;
    public bool isLevelInProgress = false;
    private Queue<Dialogue> dialogues = new Queue<Dialogue>();
    private Queue<Level> levels = new Queue<Level>();
    private List<GameObject> chickenObjects = new List<GameObject>();

    private void Start()
    {
        EnqueueDialogs();
        EnqueueLevels();
    }

    public void Interact(Dog player)
    {
        if(isLevelInProgress)
        {
            return;
        }

        Dialogue nextDialogue = dialogues.Dequeue();
        DialogueManager.GetInstance().PlayDialogue(nextDialogue);
        StartNextLevel();
    }

    public void EndLevel()
    {
        isLevelInProgress = false;
        DestroyChickens();
    }

    private void DestroyChickens()
    {
        foreach (GameObject chicken in chickenObjects)
        {
            Destroy(chicken);
        }
        chickenObjects.Clear();
    }

    private void StartNextLevel()
    {
        isLevelInProgress = true;
        Level level = levels.Dequeue();

        foreach(Vector2 pos in level.chickenSpawnPositions)
        {
            GameObject go = Instantiate(chickenPrefab, new Vector3(pos.x, pos.y, 0), Quaternion.identity);
            chickenObjects.Add(go);
        }

        Instantiate(stickPrefab, new Vector3(level.lootSpawnPosition.x, 
                    level.lootSpawnPosition.y, 0), Quaternion.identity);
    }

    private void EnqueueDialogs()
    {
        EnqueueDialog1();
        EnqueueDialog2();
        EnqueueDialog3();
        EnqueueDialog4();
    }

    private void EnqueueLevels()
    {
        EnqueueLevel1();
        EnqueueLevel2();
        EnqueueLevel3();
    }

    private void EnqueueDialog1()
    {
        Dialogue dialogue = new Dialogue();
        dialogue.name = "Farmer";

        dialogue.sentences = new string[]{
            "Hi doggo!",
            "Can you please get me that item?"
        };

        dialogues.Enqueue(dialogue);
    }

    private void EnqueueDialog2()
    {
        Dialogue dialogue = new Dialogue();
        dialogue.name = "Farmer";

        dialogue.sentences = new string[]{
            "Great job!",
            "Can you also get me that other item?"
        };

        dialogues.Enqueue(dialogue);
    }

    private void EnqueueDialog3()
    {
        Dialogue dialogue = new Dialogue();
        dialogue.name = "Farmer";

        dialogue.sentences = new string[]{
            "Excellent!",
            "Can you please get me the last item?"
        };

        dialogues.Enqueue(dialogue);
    }

    private void EnqueueDialog4()
    {
        Dialogue dialogue = new Dialogue();
        dialogue.name = "Farmer";

        dialogue.sentences = new string[]{
            "You brought me all 3 items...",
            "Good boy!"
        };

        dialogues.Enqueue(dialogue);
    }

    private void EnqueueLevel1()
    {
        Level level = new Level();
        level.chickenSpawnPositions = new Vector2[]
        {
            new Vector2(3, -1),
            new Vector2(5, -1),
            new Vector2(4, 0),
            new Vector2(0, 1)
        };

        level.lootSpawnPosition = new Vector2(1, 2);

        levels.Enqueue(level);
    }

    private void EnqueueLevel2()
    {
        Level level = new Level();
        level.chickenSpawnPositions = new Vector2[]
        {
            new Vector2(3, -1),
            new Vector2(5, -1),
            new Vector2(4, 0),
            new Vector2(0, 1)
        };

        level.lootSpawnPosition = new Vector2(1, 2);

        levels.Enqueue(level);
    }

    private void EnqueueLevel3()
    {
        Level level = new Level();
        level.chickenSpawnPositions = new Vector2[]
        {
            new Vector2(3, -1),
            new Vector2(5, -1),
            new Vector2(4, 0),
            new Vector2(0, 1)
        };

        level.lootSpawnPosition = new Vector2(1, 2);

        levels.Enqueue(level);
    }
}
