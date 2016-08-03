using UnityEngine;
using System.Collections.Generic;
using TrackedRiderUtility;

public class Main : IMod
{
    public string Identifier { get; set; }
	public static AssetBundleManager AssetBundleManager = null;
  
    private TrackRiderBinder binder;

    public void onEnabled()
    {
		if (Main.AssetBundleManager == null) {

			AssetBundleManager = new AssetBundleManager (this);
		}

        binder = new TrackRiderBinder ("248fd3fdc996afcc56102bf4a8d456d7");

        CoasterCarInstantiator coasterCarInstantiator = binder.RegisterCoasterCarInstaniator<CoasterCarInstantiator> (TrackRideHelper.GetTrackedRide("Spinning Coaster"), "SideWinderInstantiator", "Side Winder", 1, 10, 1);
        SpinningCarProxy spinningCar =  binder.RegisterCar<SpinningCarProxy> ( Main.AssetBundleManager.Car,"SideWinder", .25f,.02f,true, new Color[] { 
            new Color(255f / 255, 118f / 255, 65f / 255), 
            new Color(216f / 255, 199f / 255, 0f / 255), 
            new Color(0f / 255, 0f / 255, 0f / 255),
            new Color(195f / 255, 198f / 255, 31f / 255)}
        );
        RestraintRotationController left =  spinningCar.gameObject.AddComponent<RestraintRotationController> ();
        RestraintRotationController right =  spinningCar.gameObject.AddComponent<RestraintRotationController> ();

        left.transformName = "l_bar";
        left.closedAngles = new Vector3(45,0,0);

        right.transformName = "r_bar";
        right.closedAngles = new Vector3(-45f,0,0);


        coasterCarInstantiator.carGO = spinningCar.gameObject;
        coasterCarInstantiator.carGO.AddComponent<RestraintRotationController>().closedAngles = new Vector3(0,0,120);

        binder.Apply ();

	}

   



    public void onDisabled()
    {
        binder.Unload ();
	}

    public string Name
    {
        get { return "Spinning Car"; }
    }

    public string Description
    {
        get { return "This is a spinning car for the mini coaster."; }
    }


	public string Path { get; set; }

}

