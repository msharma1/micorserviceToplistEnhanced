// (C) king.com Ltd 2018

using UnityEngine;

using Services;

public class Toplist : MonoBehaviour {

    public GameObject toplistEntryPrefab;

    public void Display(IToplistProvider provider, IToplistIdentifier identifier)
    {
        var transformCache = transform;

        provider.Get(identifier, (entries) => {
            for (int i = 0; i < entries.Count; i++)
            {
                var entry = entries[i];
                Instantiate(toplistEntryPrefab, transformCache).GetComponent<ToplistEntry>().Setup(entry.Username, entry.Score, i + 1);
            }
        });
    }
}
