using System.Collections.Generic;

[System.Serializable]
public class ItemStructure
{
    public List<ItemSOB> items;
}
[System.Serializable]
public class ItemSOB
{
    public string Name;
    public string imagePath;
    public string Description;
}
