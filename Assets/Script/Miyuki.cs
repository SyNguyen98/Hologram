using System;
using System.Collections;
using System.Text;
using UnityEngine;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

public class Miyuki : MonoBehaviour
{
    public Animator animator;
    public AudioSource voice;
    public new AudioClip[] audio;

    private MqttClient client;
    private string controlMsg;
    private float waitTime = 60;
    private int randomIdle = 0;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        voice = GetComponent<AudioSource>();

        // create client instance 
        client = new MqttClient("chika.gq", 2502, false, null);
        client.Connect(Guid.NewGuid().ToString(), "chika", "2502");
        // register to message received 
        client.MqttMsgPublishReceived += GetMqttMessage;
        // subscribe to the topic "hologram/Miyuki" with QoS 2 
        client.Subscribe(new string[] { "hologram/Miyuki" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });

        Cursor.visible = false;

        voice.PlayOneShot(audio[0]);
        StartCoroutine(IFade());
    }

    // Update is called once per frame
    void Update()
    {
        waitTime -= Time.deltaTime;
        if (waitTime < 0)
        {
            switch (randomIdle)
            {
                case 0:
                    animator.SetTrigger("Stretch");
                    voice.PlayOneShot(audio[2]);
                    waitTime = 60;
                    randomIdle = 1;
                    break;
                case 1:
                    animator.SetTrigger("Wait");
                    voice.PlayOneShot(audio[1]);
                    waitTime = 60;
                    randomIdle = 0;
                    break;
            }

        }

        switch (controlMsg)
        {
            case "1":
                PlayAnimator("Stand By", -1);
                break;
            case "2":
                PlayAnimator("Turn On", -1);
                break;
            case "3":
                PlayAnimator("Introduce", 0);
                StartCoroutine(IFade());
                break;
        }
    }

    void GetMqttMessage(object sender, MqttMsgPublishEventArgs e)
    {
        controlMsg = Encoding.UTF8.GetString(e.Message);
        Debug.Log("Received: " + controlMsg);
    }

    void PlayAnimator(String trigger, int audioNum)
    {
        controlMsg = "";
        animator.SetTrigger(trigger);
        waitTime = 30 + GetCurrentAnimatorTime(animator);
        if (audioNum != -1)
        {
            voice.Stop();
            voice.PlayOneShot(audio[audioNum]);
        }
    }

    public float GetCurrentAnimatorTime(Animator targetAnim)
    {
        AnimatorStateInfo animState = targetAnim.GetCurrentAnimatorStateInfo(0);
        return animState.normalizedTime;
    }

    IEnumerator IFade()
    {
        GameObject.Find("KiraKira").GetComponent<KiraKira>().FadeIn();
        yield return new WaitForSeconds(0.7f);
        GameObject.Find("KiraKira").GetComponent<KiraKira>().FadeOut();
        yield return new WaitForSeconds(0.7f);
        GameObject.Find("KiraKira").GetComponent<KiraKira>().FadeIn();
        yield return new WaitForSeconds(0.7f);
        GameObject.Find("KiraKira").GetComponent<KiraKira>().FadeOut();
        yield return new WaitForSeconds(0.7f);
        GameObject.Find("KiraKira").GetComponent<KiraKira>().FadeIn();
        yield return new WaitForSeconds(0.7f);
        GameObject.Find("KiraKira").GetComponent<KiraKira>().FadeOut();
    }
}
