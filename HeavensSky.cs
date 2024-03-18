using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using ReLogic.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.ModLoader;

namespace HeavensAbove
{
    public class HeavensSky : CustomSky
    {
        private bool skyActive;

        public static Color BackgroundAmbientColor
        {
            get
            {
                Color standardAmbientLightColor = new(255, 255, 255);

                return standardAmbientLightColor;
            }
        }

        public static Asset<Texture2D> BackgroundFrameTextures
        {
            get;
            private set;
        }

        // In case we want to refactor it into multiple sky draws for both gradient sides
        public const int BackgroundTiles = 2;

        // The speed of the parallax. The closer the layer to the player the faster it will be.
        public const float ScreenParallaxSpeed = 0.1f;

        internal static void LoadTextures()
        {
            if (Main.netMode == NetmodeID.Server)
                return;

            // Load background textures.
            BackgroundFrameTextures = ModContent.Request<Texture2D>($"HeavensAbove/Assets/Textures/Backgrounds/SkyTop2");
        }

        public override void Deactivate(params object[] args)
        {
            skyActive = false;
        }

        public override void Reset()
        {
            skyActive = false;
        }

        public override bool IsActive()
        {
            return skyActive;
        }

        public override void Activate(Vector2 position, params object[] args)
        {
            skyActive = true;
        }

        public override void Draw(SpriteBatch spriteBatch, float minDepth, float maxDepth)
        {
            if (Main.gameMenu)
                return;

            // Disable ambient sky objects like wyverns and eyes appearing in the background.
            if (skyActive)
            {
                // Clears the default terraria drawns ky
                Main.instance.GraphicsDevice.Clear(Main.ColorOfTheSkies);

                // Deactivates other information
                SkyManager.Instance["Ambience"].Deactivate();
                SkyManager.Instance["Slime"].Opacity = -1f;
                SkyManager.Instance["Slime"].Deactivate();

                // Apply parallax effects.
                int x = 0;
                int y = (int)((-Main.screenPosition.Y + Main.screenHeight / 2 + Main.worldSurface * 0.35f * 16) * ScreenParallaxSpeed * 0.25f);
                Texture2D backgroundTexture = BackgroundFrameTextures.Value;

                // Loop the background horizontally.
                for (int i = -2; i <= 2; i++)
                {

                    // Cheating the sky system to make it NOT override the background style by having it parallax based on player height
                    Vector2 layerPosition;
                    if (Main.screenPosition.Y >= Main.worldSurface*0.35f*16 && Main.screenPosition.Y <= Main.worldSurface*8)
                    {
                        // Draw the base background.
                        layerPosition = new(Main.screenWidth * 0.5f - x + backgroundTexture.Width * i, y + ScreenParallaxSpeed * 800f);
                        
                    }
                    else if(Main.screenPosition.Y < Main.worldSurface * 0.35f * 16)
                    {
                        layerPosition = new(Main.screenWidth * 0.5f - x + backgroundTexture.Width * i, y);
                    }
                    else
                    {
                        y = (int)((-Main.screenPosition.Y + Main.worldSurface * 8) * ScreenParallaxSpeed * 0.4f);
                        layerPosition = new(Main.screenWidth * 0.5f - x + backgroundTexture.Width * i, y- ScreenParallaxSpeed * 800f);
                    }
                    spriteBatch.Draw(backgroundTexture, layerPosition - backgroundTexture.Size() * 0.5f, null, Main.ColorOfTheSkies, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);

                }

            }
        }

        public override void Update(GameTime gameTime)
        {
            if (!UpdateSubworldSystem.WasInSubworldLastFrame || Main.gameMenu)
                skyActive = false;
        }

        public override float GetCloudAlpha() => 0f;
    }
}
