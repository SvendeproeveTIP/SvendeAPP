package crc6478ce089e12e6c622;


public class CometRecyclerViewHolder
	extends androidx.recyclerview.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Comet.Android.Controls.CometRecyclerViewHolder, Comet", CometRecyclerViewHolder.class, __md_methods);
	}


	public CometRecyclerViewHolder (android.view.View p0)
	{
		super (p0);
		if (getClass () == CometRecyclerViewHolder.class) {
			mono.android.TypeManager.Activate ("Comet.Android.Controls.CometRecyclerViewHolder, Comet", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
		}
	}

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
