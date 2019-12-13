using UnityEngine;

public class LevelChanger : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    private GameObject prevLocation;
    private GameObject newLocation;

    public void FadeToLocation(GameObject prevLocation, GameObject newLocation)
    {
        this.prevLocation = prevLocation;
        this.newLocation = newLocation;

        _animator.SetTrigger("Fadeout");
    }

    public void OnFadeComplete()
    {
        Debug.Log("changed location");

        prevLocation.SetActive(false);
        newLocation.SetActive(true);

        _animator.Play("Fade_in");
    }
}
