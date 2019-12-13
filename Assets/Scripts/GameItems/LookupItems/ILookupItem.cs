using UnityEngine.EventSystems;

public interface ILookupItem: IPointerClickHandler
{
    void Lookup();
    void UnFocus();
}
