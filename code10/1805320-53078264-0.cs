    private int numeroSprite;
    
    private IEnumerator Count()
    {                      
         for(int i = 0; i < _images.Length; i++)
         {
               var numeroSprite = Random.Range(0, _meusOutrosSprites.Length - 1);
              _images[i].sprite = _meusOutrosSprites[numeroSprite];
         }
    
         yield return new WaitForSeconds(0);
    }
    
    public void PegarID(){
      switch (numeroSprite){
    
      // ...
