package md577e95df0f9606a34c8a54112cf06ca99;


public class MainActivity
	extends android.support.v7.app.AppCompatActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_onRequestPermissionsResult:(I[Ljava/lang/String;[I)V:GetOnRequestPermissionsResult_IarrayLjava_lang_String_arrayIHandler\n" +
			"n_onNumberClick:(Landroid/view/View;)V:__export__\n" +
			"n_onOperatorClick:(Landroid/view/View;)V:__export__\n" +
			"n_onClearClick:(Landroid/view/View;)V:__export__\n" +
			"n_onEqualsClick:(Landroid/view/View;)V:__export__\n" +
			"";
		mono.android.Runtime.register ("Calculator.MainActivity, Calculator", MainActivity.class, __md_methods);
	}


	public MainActivity ()
	{
		super ();
		if (getClass () == MainActivity.class)
			mono.android.TypeManager.Activate ("Calculator.MainActivity, Calculator", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public void onRequestPermissionsResult (int p0, java.lang.String[] p1, int[] p2)
	{
		n_onRequestPermissionsResult (p0, p1, p2);
	}

	private native void n_onRequestPermissionsResult (int p0, java.lang.String[] p1, int[] p2);


	public void onNumberClick (android.view.View p0)
	{
		n_onNumberClick (p0);
	}

	private native void n_onNumberClick (android.view.View p0);


	public void onOperatorClick (android.view.View p0)
	{
		n_onOperatorClick (p0);
	}

	private native void n_onOperatorClick (android.view.View p0);


	public void onClearClick (android.view.View p0)
	{
		n_onClearClick (p0);
	}

	private native void n_onClearClick (android.view.View p0);


	public void onEqualsClick (android.view.View p0)
	{
		n_onEqualsClick (p0);
	}

	private native void n_onEqualsClick (android.view.View p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
