using UnityEngine;

public static class HelperFunctions
{
    public static Vector3 NormalizePosition(Vector3 position)
    {
        Vector3 correct_position = position;
        correct_position.x = Mathf.Round(position.x); 
        correct_position.z = Mathf.Round(position.z); 
        return correct_position;
    }

    public static GameObject CheckForCollision(Vector3 position, LayerMask layerMask)
    {
        Vector3 verticalOffset = Vector3.up / 2f;
        Vector3 boxSize = Vector3.one / 3f;
        var colliders = Physics.OverlapBox(position + verticalOffset, boxSize, Quaternion.identity, layerMask);

        if (colliders.Length > 0)
            return colliders[0].gameObject;
        else
            return null;
    }
}