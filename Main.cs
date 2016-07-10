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

        CoasterCarInstantiator coasterCarInstantiator = binder.RegisterCoasterCarInstaniator<CoasterCarInstantiator> (TrackRideHelper.GetTrackedRide("Mini Coaster"), "SpinningCarInstantiator", "Spinning Car", 1, 9, 1);
        SpinningCar spinningCar =  binder.RegisterCar<SpinningCar> ( Main.AssetBundleManager.Car,"SpinningCar", .3f,.1f,true, new Color[] { 
            new Color(71f / 255, 71f / 255, 71f / 255), 
            new Color(176f / 255, 7f / 255, 7f / 255), 
            new Color(26f / 255, 26f / 255, 26f / 255),
            new Color(26f / 255, 26f / 255, 26f / 255)}
        );
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
        get { return "The Virginia reel  uses side friction like tracks. The tubs, have inward facing seating which spin freely on a chassis. The tubs are spun as they contacted the edges of the trough."; }
    }


	public string Path { get; set; }

}

