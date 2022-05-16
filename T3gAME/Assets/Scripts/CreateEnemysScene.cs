using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayerControl;
namespace Create
{
    public class CreateEnemysScene : MonoBehaviour
    {
        public int _enemyAll;
        private Vector2 _posScene;
        [SerializeField] private GameObject _enemy;
        public GameObject ballUpdate, _canvas;
        PlayerController playerController;
        [HideInInspector] public bool gamePause;

        private void Awake()
        {
            playerController = FindObjectOfType<PlayerController>();
        }
        void Start()
        {
            InvokeRepeating("ResCreat", 0.1f, 1f);
        }
        private void ResCreat()
        {
            if(_enemyAll == 0)
                StartCoroutine(CreatEnemys());
        }
        private IEnumerator CreatEnemys()
        {
            gamePause = true;
            float numColor_1, numColor_2, numColor_3;
            float posX = 8;
            float posY = 4;
            _posScene = new Vector2(-posX, posY);
            while (_posScene.y > 0)
            {
                while (_posScene.x < 7)
                {
                    yield return new WaitForSeconds(0.03f);
                    numColor_1 = Random.Range(0f, 2f);
                    numColor_2 = Random.Range(0f, 2f);
                    numColor_3 = Random.Range(0f, 2f);
                    _enemy.GetComponent<Image>().color = new Color(numColor_1, numColor_2, numColor_3, 1);
                    Instantiate(_enemy, _posScene += new Vector2(1, 0), _enemy.transform.rotation, _canvas.transform);
                    _enemyAll += 1;
                }
                yield return new WaitForSeconds(0.03f);
                posY -= 1;
                _posScene = new Vector2(-posX, posY);
            }
            yield return null;
            gamePause = false;
        }
    }
}
