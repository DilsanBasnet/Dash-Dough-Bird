using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
   private static BackgroundMusic run;
    void Awake()
    {
        if(run != null && run != this)
        {
            Destroy(gameObject) ;
            return;
        }
        run = this ;
        DontDestroyOnLoad(gameObject);
    }

}
