using System.Collections;
using UnityEngine;

public class CabinGraphic : MonoBehaviour
{
    [SerializeField] GameObject cabinTopSection;
    [SerializeField] GameObject cabinBotSection;
    [SerializeField] GameObject cabinInterior;
    [SerializeField] GameObject cabinTopOpenAnimation;
    [SerializeField] GameObject cabinTopCloseAnimation;
    [SerializeField] bool cabinClosing;
    [SerializeField] bool cabinOpening;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cabinOpening)
        {
            StartCoroutine(OpenCabin());
            
        }
        else if (cabinClosing)
        {
            StartCoroutine(CloseCabin());
        }
        else
        {
            cabinTopCloseAnimation.SetActive(false);
            cabinTopOpenAnimation.SetActive(false);
            //cabinInterior.SetActive(false);
        }
    }
    IEnumerator OpenCabin()
    {
        cabinOpening = false;
        //cabinBotSection.SetActive(false);
        cabinTopSection.SetActive(false);
        cabinTopOpenAnimation.SetActive(true);
        cabinTopOpenAnimation.GetComponent<Animator>().Play("OpeningAnimationCabin");
        yield return new WaitUntil(() => cabinTopOpenAnimation.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f);
        cabinInterior.SetActive(true);

    }
    IEnumerator CloseCabin()
    {
        cabinClosing = false;
        cabinTopCloseAnimation.SetActive(true);
        cabinTopCloseAnimation.GetComponent<Animator>().Play("ClosingAnimationCabin");
        yield return new WaitUntil(() => cabinTopCloseAnimation.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.5);
        cabinInterior.SetActive(false);
        yield return new WaitUntil(() => cabinTopCloseAnimation.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f);
        cabinTopCloseAnimation.SetActive(false);
       // cabinBotSection.SetActive(true);
        cabinTopSection.SetActive(true);

    }
}
