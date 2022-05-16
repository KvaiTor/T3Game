using Create;
using Info;
using UnityEngine;
using UnityEngine.UI;
public class MoveUp : MonoBehaviour
{
    GameInfo gameInfo;
    CreateEnemysScene createEnemysScene;
    private void Awake()
    {
        gameInfo = FindObjectOfType<GameInfo>();
        createEnemysScene = FindObjectOfType<CreateEnemysScene>();
    }
    void Update()
    {
        transform.Translate(Vector2.up * 10 * Time.deltaTime);
        if (transform.position.y > 5f)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameInfo.points += 1;
            createEnemysScene._enemyAll -= 1;
            UpgradeBullet(Random.Range(0, 5));
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
    private void UpgradeBullet(int i)
    {
        int colorUpdate = Random.Range(0, 3);
        switch (colorUpdate)
        {
            case 0:
                createEnemysScene.ballUpdate.GetComponent<Image>().color = Color.red;
                createEnemysScene.ballUpdate.tag = "Trio";
                break;

            case 1:
                createEnemysScene.ballUpdate.GetComponent<Image>().color = Color.green;
                createEnemysScene.ballUpdate.tag = "One";
                break;
            case 2:
                createEnemysScene.ballUpdate.GetComponent<Image>().color = Color.yellow;
                createEnemysScene.ballUpdate.tag = "Mega";
                break;
        }
        if (i == 3)
        {
            Instantiate(createEnemysScene.ballUpdate, transform.position, createEnemysScene.ballUpdate.transform.rotation, createEnemysScene._canvas.transform);
        }
    }
}


