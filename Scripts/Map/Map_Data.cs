using UnityEngine;

namespace Assets.Scripts.Map {
    public class Map_Data {
        public int mapWight { get; private set; }
        public int mapHeight { get; private set; }
        public Map_Fragment[,] fragments { get; private set; }

        public Map_Data (int mapWight, int mapHeight) {
            this.mapHeight = mapHeight;
            this.mapWight = mapWight;
            fragments = new Map_Fragment[mapHeight, mapWight];
        }

        public void LoadFragment (int x, int y) {

        }

        public void SetFragment (int x, int y, Map_Fragment fragment) {
            fragments[y, x] = fragment;
        }
    }
}
