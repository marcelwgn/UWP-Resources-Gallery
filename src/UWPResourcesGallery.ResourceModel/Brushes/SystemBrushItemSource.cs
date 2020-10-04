using Windows.Data.Json;

namespace UWPResourcesGallery.ResourceModel.Brushes
{
    public class SystemBrushItemSource : GenericItemsSource<SystemBrush>
    {
        public static void LoadSystemBrushes()
        {
            JsonObject file = GetJSONFile("/ResourceModel/Assets/SystemBrushes.json");
            JsonArray list = file["brushes"].GetArray();
            foreach (JsonValue entry in list)
            {
                JsonObject entryObject = entry.GetObject();


                string type = entryObject.GetNamedString("type");
                string key = entryObject.GetNamedString("key");

                string xamlDefinition = "";

                switch (type)
                {
                    case "SolidColorBrush":
                        if (entryObject.ContainsKey("opacity"))
                        {
                            xamlDefinition = SystemBrushDefinitionFactory.SolidColorBrushDefinition(
                                    key,
                                    entryObject.GetNamedString("color"), entryObject["opacity"].GetNumber()
                                );
                        }
                        else
                        {
                            xamlDefinition = SystemBrushDefinitionFactory.SolidColorBrushDefinition(
                                    key,
                                    entryObject.GetNamedString("color")
                                );
                        }
                        break;

                    case "StaticResource":
                        xamlDefinition = SystemBrushDefinitionFactory.StaticResourceDefinition(
                                key,
                                entryObject.GetNamedString("color")
                            );
                        break;

                    case "AcrylicBrush":
                        xamlDefinition = SystemBrushDefinitionFactory.AcrylicBrushDefinition(
                                key,
                                entryObject.GetNamedString("backgroundSource"),
                                entryObject.GetNamedString("tintColor"),
                                entryObject.GetNamedNumber("tintOpacity"),
                                entryObject.GetNamedString("fallbackColor")
                            );
                        break;
                }

                SystemBrush brush = new SystemBrush(
                    entryObject["key"].GetString(),
                    entryObject["color"].GetString(),
                    xamlDefinition
                );
                Items.Add(brush);
            }
        }
    }
}
