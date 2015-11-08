using GTA;
using GTA.Native;
using GTA.Math;
using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Collections.Generic;

namespace JustCause2VehicleExplode
{
    public class Main : Script
    {
        bool active = false;
        bool showInfo = false;
        Ped player = Game.Player.Character;

        int intensity;
        Keys enable;
        Keys disable;


        public Main()
        {
            Tick += OnTick;
            KeyDown += OnKeyDown;
            LoadSettings(@"/JC2Explode.ini");
            if (intensity > 4)
            {
                intensity = 4;
            }
            if (intensity < 1)
            {
                intensity = 1;
            }
        }
        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == enable && !active)
            {
                active = true;
                UI.Notify("JC2 Vehicle Explosion Enabled. Intensity: " + intensity);
            } 
            if (e.KeyCode == disable && active)
            {
                active = false;
                UI.Notify("JC2 Vehicle Explosion Disabled.");
            
            }
            if (e.KeyCode == Keys.T)
            {
                showInfo = true;
            }
            if (e.KeyCode == Keys.Y)
            {
                showInfo = false;
            }
        }

        private void LoadSettings(string file)
        {
            try {
                ScriptSettings config = ScriptSettings.Load(file);
                enable = config.GetValue<Keys>("Controls", "EnableKey", Keys.NumPad0);
                disable = config.GetValue<Keys>("Controls", "DisableKey", Keys.NumPad3);

                intensity = config.GetValue<int>("Settings", "Intensity", 2);
            }
            catch (Exception e)
            {
                UI.Notify("There was a problem loading ini, restoring default settings.");
                UI.Notify("~r~" + e.ToString());
                intensity = 2;
                enable = Keys.NumPad0;
                disable = Keys.NumPad3;
            }
        }

        

        private void OnTick(object sender, EventArgs e)
        {
            if (active)
            {
                switch (intensity)
                {
                    case 1:
                        if (player.IsInVehicle())
                        {
                            Vehicle[] aiVehicles = World.GetNearbyVehicles(player, 200);
                            Vehicle currentVehicle = player.CurrentVehicle;
                            if (currentVehicle.Health <= 790)
                            {
                                currentVehicle.Explode();

                            }
                            for (int i = 0; i < aiVehicles.Length; i++)
                            {
                                if (aiVehicles[i].Health <= 790)
                                {
                                    aiVehicles[i].Explode();

                                }
                            }
                        }
                        break;
                    case 2:
                        if (player.IsInVehicle())
                        {
                            Vehicle[] aiVehicles = World.GetNearbyVehicles(player, 200);
                            Vehicle currentVehicle = player.CurrentVehicle;
                            if (currentVehicle.Health <= 820)
                            {
                                currentVehicle.Explode();

                            }
                            for (int i = 0; i < aiVehicles.Length; i++)
                            {
                                if (aiVehicles[i].Health <= 820)
                                {
                                    aiVehicles[i].Explode();

                                }
                            }
                        }
                        break;
                    case 3:
                        if (player.IsInVehicle())
                        {
                            Vehicle[] aiVehicles = World.GetNearbyVehicles(player, 200);
                            Vehicle currentVehicle = player.CurrentVehicle;
                            if (currentVehicle.Health <= 850)
                            {
                                currentVehicle.Explode();

                            }
                            for (int i = 0; i < aiVehicles.Length; i++)
                            {
                                if (aiVehicles[i].Health <= 850)
                                {
                                    aiVehicles[i].Explode();

                                }
                            }
                        }
                        break;
                    case 4:
                        if (player.IsInVehicle())
                        {
                            Vehicle[] aiVehicles = World.GetNearbyVehicles(player, 200);
                            Vehicle currentVehicle = player.CurrentVehicle;
                            if (currentVehicle.Health <= 870)
                            {
                                currentVehicle.Explode();

                            }
                            for (int i = 0; i < aiVehicles.Length; i++)
                            {
                                if (aiVehicles[i].Health <= 870)
                                {
                                    aiVehicles[i].Explode();

                                }
                            }
                        }
                        break;
                }
                if (showInfo)
                {
                    if (player.IsInVehicle())
                    {
                        Vehicle currentVehicle = player.CurrentVehicle;
                        UI.ShowSubtitle("Active, Current DAMAGE: " + currentVehicle.Health.ToString());
                    }
                    
                }

            }
            else
            {

            }
        }
    }
}