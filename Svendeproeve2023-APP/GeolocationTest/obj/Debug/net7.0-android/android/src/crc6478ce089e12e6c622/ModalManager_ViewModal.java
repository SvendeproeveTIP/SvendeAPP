package crc6478ce089e12e6c622;


public class ModalManager_ViewModal
	extends androidx.fragment.app.DialogFragment
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreateView:(Landroid/view/LayoutInflater;Landroid/view/ViewGroup;Landroid/os/Bundle;)Landroid/view/View;:GetOnCreateView_Landroid_view_LayoutInflater_Landroid_view_ViewGroup_Landroid_os_Bundle_Handler\n" +
			"n_onDestroy:()V:GetOnDestroyHandler\n" +
			"";
		mono.android.Runtime.register ("Comet.Android.Controls.ModalManager+ViewModal, Comet", ModalManager_ViewModal.class, __md_methods);
	}


	public ModalManager_ViewModal ()
	{
		super ();
		if (getClass () == ModalManager_ViewModal.class) {
			mono.android.TypeManager.Activate ("Comet.Android.Controls.ModalManager+ViewModal, Comet", "", this, new java.lang.Object[] {  });
		}
	}


	public ModalManager_ViewModal (int p0)
	{
		super (p0);
		if (getClass () == ModalManager_ViewModal.class) {
			mono.android.TypeManager.Activate ("Comet.Android.Controls.ModalManager+ViewModal, Comet", "System.Int32, System.Private.CoreLib", this, new java.lang.Object[] { p0 });
		}
	}


	public android.view.View onCreateView (android.view.LayoutInflater p0, android.view.ViewGroup p1, android.os.Bundle p2)
	{
		return n_onCreateView (p0, p1, p2);
	}

	private native android.view.View n_onCreateView (android.view.LayoutInflater p0, android.view.ViewGroup p1, android.os.Bundle p2);


	public void onDestroy ()
	{
		n_onDestroy ();
	}

	private native void n_onDestroy ();

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
