namespace GameObjects {
    public class GridType {
        public string type { get; set; }

        private GridType(string type) {
            this.type = type;
        }

        public static GridType InventoryGrid => new GridType("InventoryGrid");
        public static GridType GameGrid => new GridType("GameGrid");

        public override string ToString() {
            return type;
        }

        public override bool Equals(object other) {
            if (other == null || GetType() != other.GetType()) {
                return false;
            }

            return other is GridType otherGridType && otherGridType.type == type;
        }
    }
}