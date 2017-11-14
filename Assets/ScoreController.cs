using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    //①　Lesson5で作成したPinBallをもとに作成してください：完了
    //②　UIのTextを使って得点を表示してください：完了

    //点数を表示するテキスト
    private GameObject gamescoreText;



    //③　ターゲット（大小の星と雲）にボールが衝突した時に得点を加算してください☚どの関数を使うかとか
    //これを表現するためにどうするべきかを考える。
    //疑問：どうやって1.ターゲット（大小の星と雲）にボールが衝突した時を取得する？
    //→void OnCollisionEnter(Collision other)を使って
    // ヒント：OnCollisionEnterでボールがターゲットに衝突したことを検知できると思いますので、OnCollisionEnter関数内で

    //1.何のターゲット（大小の星と雲）に衝突したかをif文を用いて分岐して検知する
    //2.ターゲットごとの得点をスコア用の変数に加算する
    //3.その変数の値をテキストに反映する

    // タグによって光らせる色を変える　☚これとvoid OnCollisionEnter(Collision other)を使う。
    // void OnCollisionEnter(Collision other)内でこれを分岐して検知する


    //④　ターゲットの種類によって取得できる点数を変えてください（例：小さい星は10点、大きい星は20点など）
    //⑤　得点は画面の右上に見やすく表示しましょう：完了

    //SmallStarTagがついているオブジェクトの点数
    //int i = 0;
    //int SmallStarTagObject = 0;
    //int LargeStarTagObject = 0;
    //int SmallCloudTagObject = 0;
    //int LargeCloudTagObject = 0;
    int totalpoints = 0;
    //GameoverTextに点数を表示
    //this.gameoverText.GetComponent<Text>().text = "Game Over";
    //衝突時に呼ばれる関数 
    //`other`はCollision型の引数なので `衝突した相手`のCollision情報が入っています。
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "SmallStarTag")  //☚この文でSmallStarTagに当たった時が表現できるはず
        {
                  //     やりたいこと： SmallStarTagObject = 0にOnCollisionEnterが呼ばれるごとに＋１すること                                                     //↑で数字使いたいが、stringしか使えない。どうする？
            //SmallStarTagObject += 1; //あ、じゃあOnCollisionEnterの中にSmallStarTagObjectに1足すようにすればいいや。
            totalpoints += 1;
            //わからないのは得点の表示の仕方。それは確かBallControllerのところでやったはず。確認
            this.gamescoreText.GetComponent<Text>().text = totalpoints.ToString();  //☚1が表示されるかまず試す。☚変数を使えば！？

                //else if (tag == "LargeStarTag")
                //{
                //    this.defaultColor = Color.yellow;
                //}
                //else if (tag == "SmallCloudTag" || tag == "LargeCloudTag")
                //{
                //    this.defaultColor = Color.blue;
                //}
        }

        if (other.gameObject.tag == "LargeStarTag")
        {
            //LargeStarTagObject += 10;
            totalpoints += 10;
            this.gamescoreText.GetComponent<Text>().text = totalpoints.ToString();
        }
        if (other.gameObject.tag == "SmallCloudTag")
        {
            //SmallCloudTagObject += 1;
            totalpoints += 1;
            this.gamescoreText.GetComponent<Text>().text = totalpoints.ToString();
        }

        if (other.gameObject.tag == "LargeCloudTag")
        {
            //LargeCloudTagObject += 10;
            totalpoints += 10;
            this.gamescoreText.GetComponent<Text>().text = totalpoints.ToString();
        }
        //別なオブジェクトに当たったら、点数が0に戻ってしまう。
        //変数をtotalpointsに統一したら、加算されるようになった。（前のやつだとそれぞれの変数<LargeCloudTagObjectとか>に
        //ばらばらに数字が足されるので、別なオブジェクトに当たるたびに0からtotalpointsがやり直される）

    }

    // Use this for initialization
    void Start()
    {
        //シーン中のScoreTextオブジェクトを取得
        this.gamescoreText = GameObject.Find("ScoreText");


    }

    // Update is called once per frame
    void Update()
    {

    }
}
