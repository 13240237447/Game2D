
public interface IEvent
{
    
}
/// <summary>
/// 格子的标签发生变化
/// </summary> 
public struct OnTileTagChange : IEvent
{
    public TileEntity Entity { private set; get; }
    
    public ETileTag OldTag { private set; get; }
    
    public ETileTag NewTag { private set; get; }

    public OnTileTagChange(TileEntity entity, ETileTag oldTag, ETileTag newTag)
    {
        Entity = entity;
        OldTag = oldTag;
        NewTag = newTag;
    }
}