using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonScript : MonoBehaviour
{
    [SerializeField]
    private float topOfScreen;

    private float risingSpeed = 2.0f;
    [SerializeField]
    private Material[] materials;
    private TextMeshProUGUI textElement;
    Rigidbody rb;
    private float timeToBreak = 1.5f;
    private bool breaking = false;

    public string English, Spanish, German, Chinese;
    public TMP_FontAsset FontAssetA;
    public TMP_FontAsset FontAssetB;
    public ParticleSystem ps;

    protected void Start()
    {
        topOfScreen = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 15.75f)).y;
        materials = GameManagerScript.instance.materials;
        textElement = this.GetComponentInChildren<TextMeshProUGUI>();
        SetText();
        ps = gameObject.GetComponent<ParticleSystem>();
        rb = gameObject.AddComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
        rb.isKinematic = true;
        SetColor();
    }

    public virtual void Update()
    {
        // Button is removed when not visible anymore
        if (this.transform.position.y > topOfScreen)
        {
            //Destroy(this.gameObject);
        }
    }

    public virtual void FixedUpdate()
    {
        if (GameManagerScript.instance.gameState == GameManagerScript.States.Playing)
        {
            rb.isKinematic = false;
            //this.transform.position = this.transform.position + new Vector3(0, risingSpeed, 0);
            rb.velocity = Vector3.up * risingSpeed;
            SetText();
        }
    }

    /// <summary>
    ///  occurs on ground pound
    /// </summary>
    public virtual void Trigger(GameObject player)
    {
        Break();
    }
	
    /// <summary>
    /// occurs on any random jump
    /// </summary>
    public virtual void Jumped()
    {

    }

    public virtual void Break()
    {
        ps.Play();
        if (breaking) return;
        StartCoroutine(BreakRoutine());
    }

    private IEnumerator BreakRoutine() {
        breaking = true;
        float start = Time.time;
        float startRot = transform.eulerAngles.z;
        float shake = 0.0f;
        float increase = 0.0f;
        Camera.main.GetComponent<CameraShake>().Shake();
        while (start + timeToBreak > Time.time) {
            shake += Time.deltaTime + increase;
            increase += Time.deltaTime * 2f;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, startRot + Mathf.Sin(shake));
            yield return new WaitForEndOfFrame();
        }
        Destroy(gameObject);
    }

    public void SetColor()
    {
        int random = Random.Range(0, 4);
        this.GetComponentInChildren<MeshFilter>().gameObject.GetComponent<Renderer>().material = materials[random];
        ps.GetComponent<ParticleSystemRenderer>().material = materials[random];
    }

    public void SetText()
    {
        switch (GameManagerScript.instance.language)
        {
            case GameManagerScript.Languages.Chinese: textElement.text = Chinese; textElement.font = FontAssetB; break;
            case GameManagerScript.Languages.English: textElement.text = English; textElement.font = FontAssetB; break;
            case GameManagerScript.Languages.German: textElement.text = German; textElement.font = FontAssetB; break;
            case GameManagerScript.Languages.Spanish: textElement.text = Spanish; textElement.font = FontAssetB; break;
        }
    }
}
