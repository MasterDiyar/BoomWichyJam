namespace BoomWichi;
using Godot;

public static class NodeExtensions
{
    public static T GetFirstParentOfType<T>(this Node node) where T : class
    {
        Node parent = node.GetParent();
        while (parent != null) {
            if (parent is T target)
                return target;
            parent = parent.GetParent();
        }
        
        return null; 
    }
}