using UnityEngine;

public static class Custom{

    //public static T findChildWithTag <T>(this GameObject parent, string searchedTag)where T:Component
    //{
    //    T[] children;

    //    children = parent.GetComponentsInChildren<T>();

    //    foreach (var child in children)
    //    {
    //        if (child.tag == searchedTag)
    //        {
    //            return child;
    //        }
    //    }

    //    throw new MissingComponentException(
    //        "Component in parent: \"" + parent.name + "\" with tag: \"" + searchedTag + "\" not found!");
    //}

    public static void SayHello()
    {
        MonoBehaviour.print("Hello");
    }

    //public static GameObject findChildWithTag(GameObject parent, string searchedTag)
    //{
    //    GameObject[] children;

    //    children = parent.GetComponentsInParent<GameObject>();

    //    foreach (var child in children)
    //    {
    //        if (child.tag == searchedTag)
    //        {
    //            return child;
    //        }
    //    }

    //    throw new MissingComponentException(
    //        "Component in parent: \"" + parent.name + "\" with tag: \"" + searchedTag + "\" not found!");
    //}

    public static GameObject findChildWithTag(GameObject parent, string searchedTag)
    {
        Component[] children;

        children = parent.GetComponentsInChildren<Component>();

        foreach (var child in children)
        {
            if (child.tag == searchedTag)
            {
                return child.gameObject;
            }
        }

        throw new MissingComponentException(
            "Component in parent: \"" + parent.name + "\" with tag: \"" + searchedTag + "\" not found!");
    }

}
