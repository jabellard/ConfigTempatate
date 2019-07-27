namespace ConfigTemplate.ContentRoot.Settings
{
    public class StaticSettings: ISettings
    {
        public string Key { get; set; }

        public StaticSettings()
        {
            Key = "The value!";
        }
    }
}