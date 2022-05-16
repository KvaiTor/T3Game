using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Create;
namespace PlayerControl
{
    public class PlayerController : MonoBehaviour
    {
        private float _speed;
        public GameObject bullet;
        CreateEnemysScene createEnemysScene;

        public delegate void OnInput();
        public static event OnInput onInput;
        private void Awake()
        {
            createEnemysScene = FindObjectOfType<CreateEnemysScene>();
        }
        void Start()
        {
            onInput += RunX;
            onInput += RunY;
            _speed = 10f;
        }


        void Update()
        {
            onInput();
            Attack();
        }

        private void RunX()
        {
           float _xRange = 8.5f;
            float _horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector2.right * _horizontalInput * _speed * Time.deltaTime);

            if (transform.position.x > _xRange)
                transform.position = new Vector2(_xRange, transform.position.y);
            else if (transform.position.x < -_xRange)
                transform.position = new Vector2(-_xRange, transform.position.y);
        }
        private void RunY()
        {
           float _verticalInput = Input.GetAxis("Vertical");
            transform.Translate(Vector2.up * _verticalInput * _speed * Time.deltaTime);

            if (transform.position.y > -1.5)
                transform.position = new Vector2(transform.position.x, -1.5f);
            else if (transform.position.y < -4.3f)
                transform.position = new Vector2(transform.position.x, -4.3f);
        }
        private void Attack()
        {
            if (Input.GetKeyDown(KeyCode.Space) && !createEnemysScene.gamePause)
                Instantiate(bullet, transform.position + new Vector3(0,1,0), bullet.transform.rotation, createEnemysScene._canvas.transform);
        }
        private void OnDisable()
        {
            onInput -= RunY;
            onInput -= RunX;
    }
    }
}
