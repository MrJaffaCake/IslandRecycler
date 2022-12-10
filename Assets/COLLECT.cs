using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

class COLLECT : MonoBehaviour
{
    public Animator animator;
    public GameObject PlastikaTekst;
    public GameObject StakloTekst;
    public GameObject MetalTekst;
    public GameObject HartijaTekst;
    private GameObject txtbox;

    public GameObject Player;
    private bool closeEnough;

    void Start()
    {
     //   PlastikaTekst.SetActive(false);
        StakloTekst.SetActive(false);
        MetalTekst.SetActive(false);
        HartijaTekst.SetActive(false);
    }

    void Update()
    {
        closeEnough = false;
        if (Vector3.Distance(Player.transform.position, transform.position) <= 99999999)
        {
            closeEnough = true;
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                BoxCollider b = hit.collider as BoxCollider;
                if (b != null && closeEnough)
                {
                    if (hit.transform.gameObject.CompareTag("Plastic"))
                    {
                        PlastikaTekst.SetActive(true);
                        txtbox = PlastikaTekst;
                        //  Invoke("DeleteImage", 3f);
                        animator.SetTrigger("comfromup");

                        StartCoroutine(FadeOut(hit));
                        StartCoroutine(WaitForFade(hit));
                    }

                    if (hit.transform.gameObject.CompareTag("Glass"))
                    {
                        StakloTekst.SetActive(true);
                        txtbox = StakloTekst;
                   //     Invoke("DeleteImage", 3f);


                        StartCoroutine(FadeOut(hit));
                        StartCoroutine(WaitForFade(hit));
                    }

                    if (hit.transform.gameObject.CompareTag("Metal"))
                    {
                        MetalTekst.SetActive(true);
                        txtbox = MetalTekst;
                     //   Invoke("DeleteImage", 3f);

                        StartCoroutine(FadeOut(hit));
                        StartCoroutine(WaitForFade(hit));
                    }

                    if (hit.transform.gameObject.CompareTag("Paper"))
                    {
                        HartijaTekst.SetActive(true);
                        txtbox = HartijaTekst;
                    //    Invoke("DeleteImage", 3f);

                        StartCoroutine(FadeOut(hit));
                        StartCoroutine(WaitForFade(hit));
                    }
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
        yield return new WaitForSeconds(5);
        hit.transform.gameObject.SetActive(false);
    }
    void DeleteImage()
    {
        txtbox.SetActive(false);    
    }
}
