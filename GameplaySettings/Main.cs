using MelonLoader;
using UnityEngine;
using System.Threading;
using System.Collections;

namespace GameplaySettings
{
    public static class BuildInfo
    {
        public const string Name = "Gameplay Settings"; // Name of the Mod.  (MUST BE SET)
        public const string Author = "Alternity"; // Author of the Mod.  (Set as null if none)
        public const string Company = null; // Company that made the Mod.  (Set as null if none)
        public const string Version = "1.0.0"; // Version of the Mod.  (MUST BE SET)
        public const string DownloadLink = "https://github.com/Alternity156/AudicaGameplaySettings"; // Download Link for the Mod.  (Set as null if none)
    }

    public class GameplaySettings : MelonMod
    {
        //The current way of tracking menu state.
        //TODO: Hook to the SetMenuState function without breaking the game
        public static MenuState.State menuState;
        public static MenuState.State oldMenuState;

        public static GameObject shellInstance = null;
        public static ShellPage SP = null;
        public static OptionsMenu OM = null;
        public static Vector3 DebugTextPosition = new Vector3(0f, -1f, 0f);


        public override void OnApplicationStart()
        {
            MelonModLogger.Log("OnApplicationStart");
        }

        public static IEnumerator GameplaySettingsMenuCoroutine()
        {
            if (shellInstance == null)
            {
                GameObject HMXshellpage = GameObject.Find("ShellPage_Settings");
                shellInstance = GameObject.Instantiate(HMXshellpage, DebugTextPosition, Quaternion.Euler(0, 100, 0));
                shellInstance.name = "Custom_Page";
                SP = shellInstance.GetComponent<ShellPage>();

                Transform page = shellInstance.transform.GetChild(0);

                for (int i = 0; i < page.childCount; i++)
                {
                    Transform child = page.GetChild(i);
                    if (child.gameObject.name.Contains("backParent"))
                    {
                        child.gameObject.SetActive(false);
                    }
                }

                Transform ShellPanelCenter = page.transform.GetChild(0);
                Transform Settings = ShellPanelCenter.transform.GetChild(2);
                Transform Options = Settings.transform.GetChild(0);
                OM = Options.GetComponent<OptionsMenu>();
            }
            

            SP.SetPageActive(true, true);

            yield return new WaitForSeconds(0.005f);

            OM.ShowPage(OptionsMenu.Page.Gameplay);
        }
        public override void OnUpdate()
        {
            //Tracking menu state
            menuState = MenuState.GetState();

            //If menu changes
            if (menuState != oldMenuState)
            {
                //Put stuff to do when a menu change triggers here
                if (menuState == MenuState.State.LaunchPage)
                {
                    MelonCoroutines.Start(GameplaySettingsMenuCoroutine());
                }

                if (oldMenuState == MenuState.State.LaunchPage)
                {
                    SP.SetPageActive(false, true);
                }


                //Updating state
                oldMenuState = menuState;
            }

            /*
            if (Input.GetKey(KeyCode.F6))
            {
                MelonCoroutines.Start(GameplaySettingsMenuCoroutine());
            }

            if (Input.GetKey(KeyCode.F4))
            {
                SP.SetPageActive(false, true);
            }
            */
        }

        /*
        public override void OnLevelWasLoaded(int level)
        {
            MelonModLogger.Log("OnLevelWasLoaded: " + level.ToString());
        }

        public override void OnLevelWasInitialized(int level)
        {
            MelonModLogger.Log("OnLevelWasInitialized: " + level.ToString());
        }

        public override void OnFixedUpdate()
        {
            MelonModLogger.Log("OnFixedUpdate");
        }

        public override void OnLateUpdate()
        {
            MelonModLogger.Log("OnLateUpdate");
        }

        public override void OnGUI()
        {
            MelonModLogger.Log("OnGUI");
        }

        public override void OnApplicationQuit()
        {
            MelonModLogger.Log("OnApplicationQuit");
        }

        public override void OnModSettingsApplied()
        {
            MelonModLogger.Log("OnModSettingsApplied");
        }
        */
    }
}
