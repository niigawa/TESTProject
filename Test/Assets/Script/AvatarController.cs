using UnityEngine;
using TMPro;
using Photon.Pun;


// MonoBehaviourPunCallbacksを継承して、photonViewプロパティを使えるようにする
public class AvatarController : MonoBehaviourPunCallbacks
{
    const float SPEED = 5.0f;
    const float RESET_POS_Y = -20;

    const float JUMP_START_SPEED = 0.1f;
    const float JUMP_SPEED_DOWN = 0.002f;
    const float JUMP_SPEED_MIN = -0.05f;

    bool m_Jumpfrag = false;
    float m_JumpSpeed = 0;

    int m_JumpNum = 0;


    private void Update()
    {
        // 自身が生成したオブジェクトだけに移動処理を行う
        if (photonView.IsMine)
        {

            //移動処理　テスト
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                this.gameObject.transform.Translate(-SPEED * Time.deltaTime, 0, 0);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                this.gameObject.transform.Translate(SPEED * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                this.gameObject.transform.Translate(0, 0, SPEED * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                this.gameObject.transform.Translate(0, 0, -SPEED * Time.deltaTime);
            }

            

            if (!m_Jumpfrag)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    m_Jumpfrag = true;
                    m_JumpSpeed = JUMP_START_SPEED;
                    m_JumpNum++;


                    var nameLabel = this.GetComponentInChildren<TextMeshProUGUI>();
                    // プレイヤー名とプレイヤーIDを表示する
                    nameLabel.text = $"{photonView.Owner.NickName}({photonView.OwnerActorNr}){m_JumpNum}";
                }
            }
            if(m_Jumpfrag)
            {
                if (m_JumpSpeed > JUMP_SPEED_MIN)
                {
                    m_JumpSpeed -= JUMP_SPEED_DOWN;
                }

                this.gameObject.transform.Translate(0, m_JumpSpeed, 0);
            }

            Vector3 pos = this.gameObject.transform.position;

            if (pos.y < RESET_POS_Y)
            {
                pos = new Vector3(0, 0, 0);
                this.gameObject.transform.position = pos;
            }

           

        }
    }

    void OnCollisionStay(Collision other)
    {
       if(other.gameObject.tag == "Floor")
        {
            m_Jumpfrag = false;
            m_JumpSpeed = 0;
             
        }
    }

}