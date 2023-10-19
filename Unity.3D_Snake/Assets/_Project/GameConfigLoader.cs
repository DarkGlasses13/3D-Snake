using Assets._Project.Core.Asset_Loading;

namespace Assets._Project
{
    public class GameConfigLoader : LocalAddressableSingleAssetLoader<GameConfig>
    {
        public override object Key => "Game Config";
    }
}
