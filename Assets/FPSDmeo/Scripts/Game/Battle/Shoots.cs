using UnityEngine;
using System.Collections;
public class Shoots : MonoBehaviour
{
    [SerializeField] int rate;//每秒发射子弹的数量
    [SerializeField] Camera m_Camera;//摄像机
    [SerializeField] GameObject bulletPrefab;//子弹预制体
    [SerializeField] Transform bulletPoint;//子弹出发点
    [SerializeField] GameObject bulletHolePrefab;//弹孔预制体
    [SerializeField] Animation playerAnimation;//人物动画

    float timer = 0;

    private Vector3 targetPoint;

    void Update()
    {
        Shoot();
    }

    /// <summary>
    /// 发射子弹
    /// </summary>
    private void Shoot()
    {
        if (playerAnimation.IsPlaying("run") || playerAnimation.IsPlaying("Roload"))
            return;
        if (Input.GetKey(KeyCode.Mouse0))//按下鼠标左键
        {
            timer+= Time.deltaTime;//计时器计时
            if (timer > 1f / rate)//如果计时大于子弹的发射速率（rate每秒几颗子弹）
            {
                //通过摄像机在屏幕中心点位置发射一条射线
                Ray ray = m_Camera.ScreenPointToRay(new Vector3(Screen.width / 2 + Random.Range(-10.0f, 10.0f), Screen.height / 2 + Random.Range(0,30.0f), 0));
                RaycastHit hitInfo;
                if (Physics.Raycast(ray, out hitInfo))//如果射线碰撞到物体
                {
                    targetPoint = hitInfo.point;//记录碰撞的目标点
                    //Debug.DrawLine(ray.origin, hitInfo.point);

                    //在射线碰撞位置生成一个弹孔预设体
                    GameObject tempHole = Instantiate(bulletHolePrefab, targetPoint, Quaternion.identity);

                    //让弹孔与射线碰撞体的法线垂直（让弹孔总是贴在物体的每一个面的表面）
                    tempHole.transform.LookAt(hitInfo.point - hitInfo.normal);

                    //让弹孔与碰撞体表面保持0.01距离（避免了弹孔与碰撞体表面完全叠加从而无法完整显示）。
                    tempHole.transform.Translate(Vector3.back * 0.1f);
                }
                else//射线没有碰撞到目标点
                {
                    //将目标点设置在摄像机自身前方1000米处
                    targetPoint = m_Camera.transform.forward * 1000;
                }
                //在枪口的位置实例化一颗子弹，按子弹发射点出的旋转，进行旋转
                GameObject bullet = Instantiate(bulletPrefab, bulletPoint.position, bulletPoint.rotation) as GameObject;
                bullet.transform.LookAt(targetPoint);//子弹的Z轴朝向目标
                timer = 0;//时间清零             
            }
        }
    }
}