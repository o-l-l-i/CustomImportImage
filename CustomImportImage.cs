using UnityEngine;
using UnityEditor;

public class CustomImportImage : AssetPostprocessor
{

    void OnPreprocessTexture()
    {
        // Trigger only for asset path that contains word "Sprite"
        if (assetPath.Contains("Sprite"))
        {
            Debug.Log("Processing texture " + assetImporter.assetPath);

            TextureImporter textureImporter = (TextureImporter) assetImporter;

            // Texture Type
            textureImporter.textureType = TextureImporterType.Sprite;

            // Texture Shape
            textureImporter.textureShape = TextureImporterShape.Texture2D;



            // Sprite Mode
            textureImporter.spriteImportMode = SpriteImportMode.Single;

            // Packing Tag
            textureImporter.spritePackingTag = "X";

            // Pixels Per Unit
            textureImporter.spritePixelsPerUnit = 100;

            // Mesh type and a few others require access via settings objects.
            // Read the existing object here, then modify it and apply it back.
            TextureImporterSettings textureSettings = new TextureImporterSettings();
            textureImporter.ReadTextureSettings(textureSettings);

            // Mesh Type
            textureSettings.spriteMeshType = SpriteMeshType.FullRect;

            // Extrude Edges
            textureSettings.spriteExtrude = 13;

            // Generate Physics Shape
            textureSettings.spriteGenerateFallbackPhysicsShape = false;
            // Set back the customized TextureImporterSettings
            textureImporter.SetTextureSettings(textureSettings);

            // Pivot
            textureImporter.spritePivot = new Vector2 (0.33f, 0.33f);



            // Advanced
            // sRGB (Color Texture)
            textureImporter.sRGBTexture = true;

            // Alpha Source
            textureImporter.alphaSource = TextureImporterAlphaSource.FromInput;

            // Alpha Is Transparency
            textureImporter.alphaIsTransparency = false;

            // Read/Write Enabled
            textureImporter.isReadable = true;

            // Generate Mip Maps
            textureImporter.mipmapEnabled = true;

            // Border Mip Maps
            textureImporter.borderMipmap = false;

            // Mip Map Filtering
            textureImporter.mipmapFilter = TextureImporterMipFilter.KaiserFilter;

            // Mip Maps Perserve Coverage
            textureImporter.mipMapsPreserveCoverage = false;

            /// Fadeout Mip Maps
            textureImporter.fadeout = true;

            // Fade Range
            textureImporter.mipmapFadeDistanceStart = 3;
            textureImporter.mipmapFadeDistanceEnd = 9;



            // Wrap Mode
            textureImporter.wrapMode = TextureWrapMode.Clamp;

            // Filter Mode
            textureImporter.filterMode = FilterMode.Bilinear;

            // Aniso Level
            textureImporter.anisoLevel = 1;



            // Default (the box in the bottom of the Inspector panel)
            textureImporter.SetPlatformTextureSettings( new TextureImporterPlatformSettings
            {
                // Max Size
                maxTextureSize = 32,

                // Resize Algorithm
                resizeAlgorithm = TextureResizeAlgorithm.Mitchell,

                // Format
                format = TextureImporterFormat.Automatic,

                // Compression
                textureCompression = TextureImporterCompression.CompressedHQ,

                // Use Crunch Compression
                crunchedCompression = true,

                // Compression quality
                compressionQuality = 75
            });



            textureImporter.SetPlatformTextureSettings( new TextureImporterPlatformSettings
            {
                // Use name to target specific platform settings
                name = "Standalone",

                // Override for PC, Mac & Linux Standalone
                overridden = true,

                // Max Size
                maxTextureSize = 32,

                // Resize Algorithm
                resizeAlgorithm = TextureResizeAlgorithm.Mitchell,

                // Format
                format = TextureImporterFormat.RGBA32
            });

        }
    }

}