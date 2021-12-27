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
    //���F�S
    private bool alive = true;
    private SceneSwitcher switcher = new SceneSwitcher();


    //�]
    private float movingSpeed = 7f;

    //��V
    private bool turnLeft, turnRight;

    //��
    private bool onGround = true;
    private Vector3 jumpDirection = new Vector3(0, 1, 0);
    public float jumpForceAmount;

    //�[�t
    private Vector3 moveDirection;
    public float moveForceAmount;

    //�ʵe
    private Animator animator;
    private Animator enemyAnimator;
    private bool run = false;
    private bool jump = false;

    //���z�ʽ�
    public Rigidbody transformRigidbody;

    //�`���B�ɶ�
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
        /************* ���`���� **************/

        if (transform.localPosition.y < -50)     //or��enemy�I�� --> die
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

        /************** ���ʬ��� *************/
        //�]�A�۰ʩb�]
        transform.localPosition += movingSpeed * Time.deltaTime * transform.forward;

        if (Input.GetKey(KeyCode.A))
        {
            transform.localPosition += movingSpeed * Time.deltaTime * -(transform.right);       //�H����left
            run = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.localPosition += movingSpeed * Time.deltaTime * transform.right;
            run = true;
        }

        //�[�t
        if (Input.GetKey(KeyCode.W))
        {
            moveDirection = transform.forward;
            transformRigidbody.AddForce(moveDirection * moveForceAmount);
        }


        //��V
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


        //���A����G�q��
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


        //�ʵe
        animator.SetBool("isRun", run);
        animator.SetBool("isJump", jump);
        enemyAnimator.SetBool("alive", alive);

    }


    /*********** �I������ **********/

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
        //����gameResult Scene
        switcher.sceneIndexDestination = 3;
        switcher.changeScene();
    }

}


/*�]
//run = false;
//��ʩb�]
if (Input.GetKey(KeyCode.W))
{
    transform.localPosition += movingSpeed * Time.deltaTime * transform.forward; 
    run = true;
}
if (Input.GetKey(KeyCode.S))
{
    transform.localPosition += movingSpeed * Time.deltaTime * -(transform.forward);     //�H����back
    run = true;
}
*/
