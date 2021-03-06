    using UnityEngine;
    
    public class Cup : MonoBehaviour
    {  
        public Vector3 startPos;
        private float lerp = 0, duration = 1;
        Vector3 theNewPos;
    	
        void Awake()
        {
            startPos = transform.position;
        }
    
    	void Start ()
        {       
            
    	}	
    
    	void Update() 
        {
            if (theNewPos != startPos) 
            { 
                lerp += Time.deltaTime / duration;
                transform.position = Vector3.Lerp (startPos, theNewPos, lerp);
            }
        }
      
        public void MoveToSpot(Vector3 pos)
        {
             theNewPos = pos;
             lerp = 0f;
        }
    }
