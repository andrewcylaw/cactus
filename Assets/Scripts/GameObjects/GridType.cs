namespace GameObjects {
    public class GridType {
        public string Type { get; set; }

        private GridType(string type) {
            Type = type;
        }

        public static GridType InventoryGrid => new GridType("InventoryGrid");
        public static GridType GameGrid => new GridType("GameGrid");

        public override bool Equals(object other) {
            if (other == null || GetType() != other.GetType()) {
                return false;
            }

            return other is GridType otherGridType && otherGridType.Type == Type;
        }
    }
}