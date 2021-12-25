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
    private float movingSpeed = 10f;

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
    private bool run = false;
    private bool jump = false;

    //物理性質
    public Rigidbody transformRigidbody;


    // Start is called before the first frame update
    void Start()
    {
        transformRigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        /************* 死亡相關 **************/
        
        if(transform.localPosition.y < -50)     //or跟enemy碰到 --> die
        {
            alive = false;
        }

        if(alive == false)
        {
            //Debug.Log("You Die");

            //跳到gameResult Scene
            switcher.sceneIndexDestination = 3;
            switcher.changeScene();
        }


        /************** 移動相關 *************/
        //跑，自動奔跑
        run = true;
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

        if(turnLeft == true)
        {
            transform.Rotate(new Vector3(0f, -90f, 0f));
        }
        if(turnRight == true)
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

        if(transform.localPosition.y < 1 && transform.localPosition.y > -1)
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

    }
    

    /*********** 碰撞相關 **********/

    /*
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "viking")
        {
            transform.localScale *= 1.5f;
        }
        else
        {
            transform.localScale /= 1.5f;
        }
    }

    public void OnCollisionStay(Collision collision)
    {
        
    }

    public void OnCollisionExit(Collision collision)
    {
        
    }
    */


    /************ Trigger相關 ************/
    /*可用在金幣、Enemy*/

    /*
    public void OnTriggerEnter(Collider collider)
    {
        Destroy(collider.gameObject);
    }

    public void OnTriggerStay(Collider other)
    {
        
    }

    public void OnTriggerExit(Collider other)
    {
        
    }

    */
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
