    float step = 100;//find a proper value for this
    void Start()
    {
        Button b = gameObject.GetComponent<Button>();
        b.onClick.AddListener(
            ()=>
            {
                Camera.main.gameObject.transform.Translate(step, 0, 0);
            }
        );
    }
