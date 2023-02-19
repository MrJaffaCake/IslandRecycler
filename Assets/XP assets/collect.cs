using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

class collect : MonoBehaviour
{
    //public TextMeshProUGUI PlastikaTekst;
    //public TextMeshProUGUI StakloTekst;
    //public TextMeshProUGUI MetalTekst;
    //public TextMeshProUGUI HartijaTekst;
    //private TextMeshProUGUI txtbox;

    public GameObject Player;
    private bool closeEnough, clicked = false;

    [SerializeField] private getxp xpStats;

    void Start()
    {
        //PlastikaTekst.enabled = false;
        //StakloTekst.enabled = false;
        //MetalTekst.enabled = false;
        //HartijaTekst.enabled = false;
    }

    void Update()
    {
        closeEnough = false;
        if (Vector3.Distance(Player.transform.position, transform.position) <= 2)
        {
            closeEnough = true;
        }

        if (Input.GetMouseButtonDown(0) && !clicked)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                BoxCollider b = hit.collider as BoxCollider;
                if (b != null && closeEnough)
                {
                    clicked = true;

                    xpStats.addcollectexp((int)Random.Range(15,26), (int)Random.Range(5,16));
                    
                    FindObjectOfType<AudioManager>().Play("Collect");
                    StartCoroutine(FadeOut(hit));
                    StartCoroutine(WaitForFade(hit));

                    
                    /*
                    if (hit.transform.gameObject.CompareTag("Plastika"))
                    {
                        PlastikaTekst.enabled = true;
                        txtbox = PlastikaTekst;
                        Invoke("InactText", 3.5f);
                        Invoke("FadeText", 3f);

                        StartCoroutine(FadeOut(hit));
                        StartCoroutine(WaitForFade(hit));
                    }

                    if (hit.transform.gameObject.CompareTag("Staklo"))
                    {
                        StakloTekst.enabled = true;
                        txtbox = StakloTekst;
                        Invoke("InactText()", 3.5f);
                        Invoke("FadeText", 3f);

                        StartCoroutine(FadeOut(hit));
                        StartCoroutine(WaitForFade(hit));
                    }

                    if (hit.transform.gameObject.CompareTag("Metal"))
                    {
                        MetalTekst.enabled = true;
                        txtbox = MetalTekst;
                        Invoke("InactText", 3.5f);
                        Invoke("FadeText", 3f);

                        StartCoroutine(FadeOut(hit));
                        StartCoroutine(WaitForFade(hit));
                    }

                    if (hit.transform.gameObject.CompareTag("Hartija"))
                    {
                        HartijaTekst.enabled = true;
                        txtbox = HartijaTekst;
                        Invoke("InactText", 3.5f);
                        Invoke("FadeText", 3f);

                        StartCoroutine(FadeOut(hit));
                        StartCoroutine(WaitForFade(hit));
                    }
                    */
                }
            }
        }
    }

    IEnumerator FadeOut(RaycastHit hit)
    {
        var mat = hit.transform.gameObject.GetComponent<Renderer>().material;
        while (mat.color.a >= 0)
        {
            var newAlpha = Mathf.MoveTowards(mat.color.a, 0, 3.5f * Time.deltaTime);
            mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, newAlpha);
            yield return null;
        }
    }

    IEnumerator WaitForFade(RaycastHit hit)
    {
        yield return new WaitForSeconds(1);
        hit.transform.gameObject.SetActive(false);
    }

    /*
    void InactText()
    {
        txtbox.enabled = false;
    }
    void FadeText()
    {
        txtbox.CrossFadeAlpha(0.0f, 0.5f, false);
    }
    */
}