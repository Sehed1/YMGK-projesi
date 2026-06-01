using UnityEngine;

public class ObjectSelector : MonoBehaviour
{
    public GameObject[] allObjects;

    private GameObject currentSelected = null;

    public void SelectObject(GameObject selected)
    {
        // إذا ضغطت نفس العنصر → رجع الكل
        if (currentSelected == selected)
        {
            foreach (GameObject obj in allObjects)
            {
                SetObjectVisible(obj, true);
            }

            currentSelected = null;
        }
        else
        {
            foreach (GameObject obj in allObjects)
            {
                if (obj != selected)
                    SetObjectVisible(obj, false);
                else
                    SetObjectVisible(obj, true);
            }

            currentSelected = selected;
        }
    }

    // 🔥 دالة تتحكم بالإظهار بدون تعطيل الكائن
    void SetObjectVisible(GameObject obj, bool visible)
    {
        // يخفي/يظهر كل الـ Renderers داخل الكائن (حتى الأطفال)
        Renderer[] renderers = obj.GetComponentsInChildren<Renderer>();

        foreach (Renderer r in renderers)
        {
            r.enabled = visible;
        }
    }
}