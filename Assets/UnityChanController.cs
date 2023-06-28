using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour
{
    //�A�j���[�V����������ׂ̃R���|�[�l���g������
    Animator animator;

    //Unity�������ړ�������R���|�[�l���g������(�ǉ�)
    Rigidbody2D rigid2D;

    //�n�ʂ̈ʒu
    private float groundLevel = -3.0f;

    //�W�����v�̑��x�̌���(�ǉ�)
    private float dump = 0.8f;

    //�W�����v�̑��x(�ǉ�)
    float jumpVelocity = 20;

    //�Q�[���I�[�o�[�ɂȂ�ʒu(�ǉ��Q)
    private float deadLine = -9;


    // Start is called before the first frame update
    void Start()
    {
        //�A�j���[�^�[�̃R���|�[�l���g���擾����
        this.animator = GetComponent<Animator>();

        //Rigidbody2D�̃R���|�[�l���g���擾����(�ǉ�)
        this.rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //����A�j���[�V�������Đ����邽�߂ɁAAnimator�̃p�����[�^�[�𒲐�����
        this.animator.SetFloat("Horizontal", 1);

        //���n���Ă��邩�ǂ����𒲂ׂ�
        bool isGround = (transform.position.y > this.groundLevel) ? false : true;

        this.animator.SetBool("isGround", isGround);

        //�W�����v��Ԃ̂Ƃ��ɂ̓{�����[����0�ɂ���(�ǉ��R)
        GetComponent<AudioSource>().volume = (isGround) ? 1 : 0;

        //���n��ԂŃN���b�N���ꂽ�ꍇ(�ǉ�)
        if(Input.GetMouseButtonDown (0) && isGround)
        {
            //������̗͂�������(�ǉ�)
            this.rigid2D.velocity = new Vector2(0, this.jumpVelocity);
        }

        //�N���b�N���~�߂��������ւ̑��x����������(�ǉ�)
        if(Input.GetMouseButton (0) == false)
        {
            if(this.rigid2D.velocity.y > 0)
            {
                this.rigid2D.velocity *= this.dump;
            }
        }

        //�f�b�h���C���𒴂����ꍇ�Q�[���I�[�o�[�ɂ���(�ǉ��Q)
        if(transform.position.x < this.deadLine)
        {
            //UIController��GameOver�֐����Ăяo���ĉ�ʏ�ɁuGameOver�v�ƕ\������(�ǉ��Q)
            GameObject.Find("Canvas").GetComponent<UIController>().GameOver();

            //Unity������j������(�ǉ��Q)
            Destroy(gameObject);
        }
    }
}