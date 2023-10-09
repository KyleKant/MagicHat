using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    private GameManager gameManager;
    private GameData gameData;
    private LeftPointController leftPointController;
    private RightPointController rightPointController;
    private MagicHatController magicHatController;
    private string level = "";
    private float direction;
    private void Start()
    {
        gameManager = FindObjectOfType(typeof(GameManager)) as GameManager;
        gameData = gameManager.ReadGameData();
        leftPointController = FindObjectOfType<LeftPointController>();
        rightPointController = FindObjectOfType<RightPointController>();
        magicHatController = FindObjectOfType<MagicHatController>();
        switch (gameData.Level)
        {
            case GameLevel.Easy:
                level = "Easy";
                direction = 0f;
                break;
            case GameLevel.Normal:
                direction = Random.Range(-1f, 1f);
                level = "Normal";
                break;
            case GameLevel.Hard:
                direction = Random.Range(-3f, 3f);
                level = "Hard";
                break;
        }
    }
    private void Update()
    {
        switch (level)
        {
            case "Easy":
                MovementAtEasyLevel();
                break;
            case "Normal":
                MovementAtNormalLevel();
                break;
            case "Hard":
                MovementAtHardLevel();
                break;
        }
    }
    private void MovementAtEasyLevel()
    {
        this.transform.Translate(direction * magicHatController.scoreLimitIncreaseTimesNum * 0.5f * Time.deltaTime, speed * magicHatController.scoreLimitIncreaseTimesNum * 0.5f * Time.deltaTime, 0f);
    }
    private void MovementAtNormalLevel()
    {
        if (this.transform.position.x - (this.transform.localScale.x / 2f) < leftPointController.transform.position.x)
        {
            direction = Random.Range(0, 1);
        }
        else if (this.transform.position.x + (this.transform.localScale.x / 2f) > rightPointController.transform.position.x)
        {
            direction = Random.Range(-1, 0);
        }
        this.transform.position += 0.5f * magicHatController.scoreLimitIncreaseTimesNum * Time.deltaTime * new Vector3(direction, speed, 0f);
    }
    private void MovementAtHardLevel()
    {
        if (this.transform.position.x - (this.transform.localScale.x / 2f) < leftPointController.transform.position.x)
        {
            direction = Random.Range(0, 3);
        }
        else if (this.transform.position.x + (this.transform.localScale.x / 2f) > rightPointController.transform.position.x)
        {
            direction = Random.Range(-3, 0);
        }
        this.transform.position += 0.5f * magicHatController.scoreLimitIncreaseTimesNum * Time.deltaTime * new Vector3(direction, speed, 0f);
    }
}
