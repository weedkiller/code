    public float swipeSpeed = 0.002f;
    
    private Vector3 lastMousePos;
    
    private void Update 
    {
        if(Input.mousePresent)
        {
            if(Input.GetMouseButton(0))
            {
                var currentMousePos = Input.mousePosition;
                var mouseDeltaPosition = currentMousePos - lastMousePos;
                transform.Translate( 0f,0f, -mouseDeltaPosition.x * swipespeed);
                lastMousePos = currentMousePos ;
            }
        }
        else
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                // Get movement of the finger since last frame
                var touchDeltaPosition = Input.GetTouch(0).deltaPosition;
                // Move object across XY plane
                transform.Translate( 0f,0f, -touchDeltaPosition.x * swipespeed);
            }
        }
    }
