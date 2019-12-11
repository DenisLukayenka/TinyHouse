using UnityEngine;

public interface IGameItem
{
    OutlineItemBase OutlineItem { get; }
    bool Execute(GameObject obj);
}
