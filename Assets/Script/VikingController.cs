using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]

public class VikingController : MonoBehaviour
{
    //死了沒
    private bool alive = true;
    private SceneSwitcher switcher = new SceneSwitcher();


    //跑
    private float movingSpeed = 7f;

    //轉向
    private bool turnLeft, turnRight;

    //跳
    private bool onGround = true;
    private Vector3 jumpDirection = new Vector3(0, 1, 0);
    public float jumpForceAmount;

    //加速
    private Vector3 moveDirection;
    public float moveForceAmount;

    //動畫
    private Animator animator;
    private Animator enemyAnimator;
    private bool run = false;
    private bool jump = false;

    //物理性質
    public Rigidbody transformRigidbody;

    //總分、時間
    public static int totalScore;
    public static float survivalTime;

    public Transform enemy;

    // Start is called before the first frame update
    void Start()
    {
        transformRigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        enemyAnimator = enemy.GetComponent<Animator>();

        totalScore = 0;
        survivalTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        /************* 死亡相關 **************/

        if (transform.localPosition.y < -50)     //or跟enemy碰到 --> die
        {
            alive = false;
        }

        if (alive == false)
        {
            //animator.SetBool("isRun", run);
            StartCoroutine(GameOver());
            run = false;
        }
        if (alive == true)
        {
            survivalTime += Time.deltaTime;
            run = true;
        }

        /************** 移動相關 *************/
        //跑，自動奔跑
        transform.localPosition += movingSpeed * Time.deltaTime * transform.forward;

        if (Input.GetKey(KeyCode.A))
        {
            transform.localPosition += movingSpeed * Time.deltaTime * -(transform.right);       //人物的left
            run = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.localPosition += movingSpeed * Time.deltaTime * transform.right;
            run = true;
        }

        //加速
        if (Input.GetKey(KeyCode.W))
        {
            moveDirection = transform.forward;
            transformRigidbody.AddForce(moveDirection * moveForceAmount);
        }


        //轉向
        turnLeft = Input.GetKeyDown(KeyCode.J);
        turnRight = Input.GetKeyDown(KeyCode.K);

        if (turnLeft == true)
        {
            transform.Rotate(new Vector3(0f, -90f, 0f));
        }
        if (turnRight == true)
        {
            transform.Rotate(new Vector3(0f, 90f, 0f));
        }


        //跳，不能二段跳
        jump = false;

        if ((onGround == true) && (Input.GetKey(KeyCode.Space)))
        {
            onGround = false;
            transformRigidbody.AddForce(jumpDirection * jumpForceAmount);
        }

        if (transform.localPosition.y < 1 && transform.localPosition.y > -1)
        {
            onGround = true;
        }
        else
        {
            jump = true;
        }


        //動畫
        animator.SetBool("isRun", run);
        animator.SetBool("isJump", jump);
        enemyAnimator.SetBool("alive", alive);

    }


    /*********** 碰撞相關 **********/

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "coin(Clone)")
        {
            Destroy(collision.gameObject);
            totalScore++;
        }
        if (collision.gameObject.name == "barrier_tree(Clone)")
        {
            alive = false;
        }
        if (collision.gameObject.name == "barrier_mashroom(Clone)")
        {
            alive = false;
        }

    }


    IEnumerator GameOver()
    {
        transform.localPosition -= movingSpeed * Time.deltaTime * transform.forward;
        enemy.position += (movingSpeed / 5) * Time.deltaTime * enemy.transform.forward;
        yield return new WaitForSeconds(2f);
        //跳到gameResult Scene
        switcher.sceneIndexDestination = 3;
        switcher.changeScene();
    }

}


/*跑
//run = false;
//手動奔跑
if (Input.GetKey(KeyCode.W))
{
    transform.localPosition += movingSpeed * Time.deltaTime * transform.forward; 
    run = true;
}
if (Input.GetKey(KeyCode.S))
{
    transform.localPosition += movingSpeed * Time.deltaTime * -(transform.forward);     //人物的back
    run = true;
}
*/
