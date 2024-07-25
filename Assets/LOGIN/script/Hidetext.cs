using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ActivateOnInputFieldSelect : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public GameObject targetObject;  // GameObject sẽ được kích hoạt
    public InputField inputField;    // Tham chiếu tới InputField

    private void Start()
    {
        // Đảm bảo GameObject đang tắt
        if (targetObject != null)
        {
            targetObject.SetActive(false);
        }
    }

    public void OnSelect(BaseEventData eventData)
    {
        // Kích hoạt GameObject khi InputField được chọn
        if (targetObject != null)
        {
            targetObject.SetActive(true);
        }
    }

    public void OnDeselect(BaseEventData eventData)
    {
        // Kiểm tra nếu InputField có ký tự thì giữ trạng thái active
        if (targetObject != null)
        {
            if (string.IsNullOrEmpty(inputField.text))
            {
                targetObject.SetActive(false);
            }
        }
    }
}
