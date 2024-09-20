using UnityEngine;

public class UIScaler : MonoBehaviour
{
    public RectTransform uiElement; // The UI element to position and resize
    public RectTransform referenceObject; // The reference object to align with
    public bool alignLeft = false; // Align with the left side of the screen
    public bool alignRight = false; // Align with the right side of the screen
    public bool alignTop = false; // Align with the top side of the screen
    public bool alignBottom = false; // Align with the bottom side of the screen
    public bool alignHorizontalCenter = true; // Align with the horizontal center of the screen
    public bool alignVerticalCenter = true; // Align with the vertical center of the screen
    public bool alignWithObject = false; // Whether to align with the reference object
    [Range(0f, 1f)] public float distanceFromLeftPercentage = 0.1f; // Distance from the left edge of the screen as percentage
    [Range(0f, 1f)] public float distanceFromRightPercentage = 0.1f; // Distance from the right edge of the screen as percentage
    [Range(0f, 1f)] public float distanceFromTopPercentage = 0.1f; // Distance from the top edge of the screen as percentage
    [Range(0f, 1f)] public float distanceFromBottomPercentage = 0.1f; // Distance from the bottom edge of the screen as percentage
    [Range(-1f, 1f)] public float horizontalCenterDistancePercentage = 0.0f; // Horizontal distance from the center of the reference object (negative for left, positive for right)
    [Range(-1f, 1f)] public float verticalCenterDistancePercentage = 0.0f; // Vertical distance from the center of the reference object (negative for down, positive for up)
    [Range(0f, 1f)] public float widthPercentage = 0.1f; // Width of the UI element as a percentage of screen width (0 to 1)
    [Range(0f, 1f)] public float heightPercentage = 0.1f; // Height of the UI element as a percentage of screen height (0 to 1)

    void Start()
    {
        if (uiElement != null)
        {
            SetUIElementProperties();
        }
        else
        {
            Debug.LogWarning("UI Element is not assigned.");
        }
    }

    void SetUIElementProperties()
    {
        // Get screen width and height
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        // Calculate width and height based on percentage of screen dimensions
        float elementWidth = screenWidth * widthPercentage;
        float elementHeight = screenHeight * heightPercentage;

        // Set size
        uiElement.sizeDelta = new Vector2(elementWidth, elementHeight);

        if (!alignWithObject)
        {
            // Set anchors if not aligning with a reference object
            Vector2 anchorMin = Vector2.zero;
            Vector2 anchorMax = Vector2.zero;

            // Handle horizontal alignment
            if (alignLeft && !alignRight && !alignHorizontalCenter)
            {
                anchorMin.x = 0;
                anchorMax.x = 0;
            }
            else if (!alignLeft && alignRight && !alignHorizontalCenter)
            {
                anchorMin.x = 1;
                anchorMax.x = 1;
            }
            else if (alignHorizontalCenter && !alignLeft && !alignRight)
            {
                anchorMin.x = 0.5f;
                anchorMax.x = 0.5f;
            }

            // Handle vertical alignment
            if (alignBottom && !alignTop && !alignVerticalCenter)
            {
                anchorMin.y = 0;
                anchorMax.y = 0;
            }
            else if (!alignBottom && alignTop && !alignVerticalCenter)
            {
                anchorMin.y = 1;
                anchorMax.y = 1;
            }
            else if (alignVerticalCenter && !alignBottom && !alignTop)
            {
                anchorMin.y = 0.5f;
                anchorMax.y = 0.5f;
            }

            uiElement.anchorMin = anchorMin;
            uiElement.anchorMax = anchorMax;

            // Set position
            Vector2 anchoredPosition = Vector2.zero;

            if (alignLeft)
            {
                anchoredPosition.x = screenWidth * distanceFromLeftPercentage;
            }
            else if (alignRight)
            {
                anchoredPosition.x = -screenWidth * distanceFromRightPercentage;
            }
            else if (alignHorizontalCenter)
            {
                anchoredPosition.x = 0; // No offset when centered
            }

            if (alignBottom)
            {
                anchoredPosition.y = screenHeight * distanceFromBottomPercentage;
            }
            else if (alignTop)
            {
                anchoredPosition.y = -screenHeight * distanceFromTopPercentage;
            }
            else if (alignVerticalCenter)
            {
                anchoredPosition.y = 0; // No offset when centered
            }

            uiElement.anchoredPosition = anchoredPosition;
        }
        else if (alignWithObject && referenceObject != null)
        {
            // Align with the reference object's position
            Vector2 refSize = referenceObject.sizeDelta;
            Vector2 refAnchoredPosition = referenceObject.anchoredPosition;

            // Calculate the distance from the center of the reference object
            float distanceX = refSize.x * horizontalCenterDistancePercentage;
            float distanceY = refSize.y * verticalCenterDistancePercentage;

            // Adjust the UI element's position based on the reference object's center
            Vector2 adjustedPosition = new Vector2(
                refAnchoredPosition.x + distanceX,
                refAnchoredPosition.y + distanceY
            );

            uiElement.anchoredPosition = adjustedPosition;
        }
    }
}
