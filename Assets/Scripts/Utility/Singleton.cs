/* Enforces a singleton pattern which is placed on the Game Manager game object
   which holds all scripts that are vital to be kept between switching scenes */

using UnityEngine;
using System.Collections;

public class Singleton : MonoBehaviour 
{
	public static Singleton instance = null;
	
	void Awake ()
	{
		if (instance == null)
	    {
	        instance = this;
	    }
	    else if (instance != this)
	    {
	        Destroy(gameObject);
	    }

	    DontDestroyOnLoad(gameObject);
	}
}
